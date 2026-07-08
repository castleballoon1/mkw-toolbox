using kartlib.Serial;
using System.Runtime.InteropServices;

namespace BillysToolbox.Tools.MagicMinimap
{
    public partial class MagicMinimapProgressForm : Form
    {
        private string? FilePath;

        public byte[]? BrresFileBytes { get; private set; }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public MagicMinimapProgressForm(string filepath)
        {
            FilePath = filepath;
            InitializeComponent();
            label2.Text = "Centering Minimap...";
        }

        public MagicMinimapProgressForm(byte[] brresFileBytes)
        {
            BrresFileBytes = brresFileBytes;
            InitializeComponent();
            label2.Text = "Centering Minimap...";
        }

        private void MagicMinimapProgressForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ProcessBrresBytes(byte[] brresBytes, IProgress<int> progress)
        {
            progress?.Report(10);
            byte[] modifiedBytes = MinimapHelper.ExecuteMinimapAlignment(brresBytes);
            progress?.Report(90);
            BrresFileBytes = modifiedBytes;
            progress?.Report(100);
        }

        private void ProcessBrresDirectly(string filePath, IProgress<int> progress)
        {
            progress?.Report(10);
            byte[] fileBytes = File.ReadAllBytes(filePath);
            byte[] modifiedBytes = MinimapHelper.ExecuteMinimapAlignment(fileBytes);

            progress?.Report(90);
            File.WriteAllBytes(filePath, modifiedBytes);
            progress?.Report(100);
        }

        private void ProcessU8Archive(string filePath, IProgress<int> progress)
        {
            progress?.Report(5);
            byte[] fileBytes = File.ReadAllBytes(filePath);
            bool isYaz0 = false;

            if (fileBytes.Length >= 4 &&
                fileBytes[0] == 0x59 && fileBytes[1] == 0x61 &&
                fileBytes[2] == 0x7A && fileBytes[3] == 0x30)
            {
                isYaz0 = true;
                fileBytes = YAZ0.Decompress(fileBytes);
            }

            progress?.Report(20);
            U8 archive = new U8(fileBytes, filePath);
            int nodeIndex = archive.FindIndexFromName("map_model.brres");

            if (nodeIndex == -1)
            {
                throw new Exception("The selected archive does not contain a 'map_model.brres' file.");
            }

            U8._Node mapModelNode = archive.Nodes[nodeIndex];

            byte[] modifiedBrresBytes = MinimapHelper.ExecuteMinimapAlignment(mapModelNode.Data);

            mapModelNode.Data = modifiedBrresBytes;
            progress?.Report(80);

            byte[] repackedArchive = archive.Write();

            if (isYaz0)
            {
                repackedArchive = YAZ0.Compress(repackedArchive);
            }

            progress?.Report(95);
            File.WriteAllBytes(filePath, repackedArchive);
            progress?.Report(100);
        }

        private async void MagicMinimapProgressForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (FilePath != null)
                {
                    string extension = Path.GetExtension(FilePath).ToLower();
                    var progress = new Progress<int>(percent =>
                    {
                        progressBar1.Value = Math.Max(0, Math.Min(100, percent));
                    });

                    await Task.Run(() =>
                    {
                        if (extension == ".brres")
                        {
                            ProcessBrresDirectly(FilePath, progress);
                        }
                        else if (extension == ".szs" || extension == ".arc" || extension == ".u8")
                        {
                            ProcessU8Archive(FilePath, progress);
                        }
                    });
                    label2.Text = "Minimap successfully centered!";
                }
                else if (BrresFileBytes != null)
                {
                    var progress = new Progress<int>(percent =>
                    {
                        progressBar1.Value = Math.Max(0, Math.Min(100, percent));
                    });

                    await Task.Run(() =>
                    {
                        ProcessBrresBytes(BrresFileBytes, progress);
                    });
                    label2.Text = "Minimap successfully centered!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
