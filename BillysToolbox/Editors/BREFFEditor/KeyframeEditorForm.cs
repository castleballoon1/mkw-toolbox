using kartlib.Serial;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;

namespace ParticleEditor.Control
{
    internal partial class KeyframeEditorForm : Form
    {
        private AnimationDataNode _node;
        private BindingList<KeyframeEntry> _keyframes;

        public KeyframeEditorForm(AnimationDataNode node)
        {
            InitializeComponent();
            _node = node;
            _keyframes = new BindingList<KeyframeEntry>();

            dataGridView1.AutoGenerateColumns = false;

            SetupColumns();
            LoadKeyframes();

            btnSave.Click += BtnSave_Click;
        }

        private void SetupColumns()
        {
            bool isU8 = _node.CurveFlag == BREFF.AnimType.ParticleU8;
            byte kindEnable = _node.AnimationItem.KindEnable;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Frame", HeaderText = "Frame" });

            dataGridView1.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "ValueType",
                HeaderText = "Value Type",
                DataSource = Enum.GetValues(typeof(BREFF.KeyType)),
                FlatStyle = FlatStyle.Flat
            });

            dataGridView1.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "Interpolation",
                HeaderText = "Interpolation",
                DataSource = Enum.GetValues(typeof(BREFF.KeyCurveType)),
                FlatStyle = FlatStyle.Flat
            });

            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "StartSlopeAdjust", HeaderText = "Start Slope Adj" });
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "EndSlopeAdjust", HeaderText = "End Slope Adj" });

            if (isU8)
            {
                if ((kindEnable & 0x01) > 0) dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "R", HeaderText = "Red (R)" });
                if ((kindEnable & 0x02) > 0) dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "G", HeaderText = "Green (G)" });
                if ((kindEnable & 0x04) > 0) dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "B", HeaderText = "Blue (B)" });

                if ((kindEnable & 0x07) == 0) dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Val", HeaderText = "Alpha / Val" });
            }
            else
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Value", HeaderText = "Value (Float)" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "InSlope", HeaderText = "In Slope" });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "OutSlope", HeaderText = "Out Slope" });
            }

            dataGridView1.DataSource = _keyframes;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadKeyframes()
        {
            byte[] data = _node.AnimationItem.KeyTableData;
            if (data == null || data.Length < 4) return;

            EndianReader br = new EndianReader(data, Endianness.BigEndian);
            try
            {
                ushort entryCount = br.ReadUInt16();
                br.ReadUInt16();

                bool isU8 = _node.CurveFlag == BREFF.AnimType.ParticleU8;
                byte kindEnable = _node.AnimationItem.KindEnable;

                for (int i = 0; i < entryCount; i++)
                {
                    var kf = new KeyframeEntry();
                    kf.Frame = br.ReadUInt16();
                    kf.ValueType = (BREFF.KeyType)br.ReadByte();

                    byte curveFlags = br.ReadByte();
                    kf.Interpolation = (BREFF.KeyCurveType)(curveFlags & 0x03);
                    kf.StartSlopeAdjust = (curveFlags & 0x04) > 0;
                    kf.EndSlopeAdjust = (curveFlags & 0x08) > 0;

                    if (isU8)
                    {
                        byte count = 0;
                        if ((kindEnable & 0x01) > 0) { kf.R = br.ReadByte(); count++; }
                        if ((kindEnable & 0x02) > 0) { kf.G = br.ReadByte(); count++; }
                        if ((kindEnable & 0x04) > 0) { kf.B = br.ReadByte(); count++; }
                        if (count == 0) { kf.Val = br.ReadByte(); }
                    }
                    else
                    {
                        kf.Value = br.ReadSingle();
                        if (kf.Interpolation == BREFF.KeyCurveType.Hermite)
                        {
                            kf.InSlope = br.ReadSingle();
                            kf.OutSlope = br.ReadSingle();
                        }
                    }
                    _keyframes.Add(kf);
                }
            }
            finally
            {
                br.Close();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (var ms = new MemoryStream())
            {
                EndianWriter bw = new EndianWriter(ms, Endianness.BigEndian);
                try
                {
                    bw.WriteUInt16((ushort)_keyframes.Count);
                    bw.WriteUInt16(0);

                    bool isU8 = _node.CurveFlag == BREFF.AnimType.ParticleU8;
                    byte kindEnable = _node.AnimationItem.KindEnable;

                    foreach (var kf in _keyframes)
                    {
                        bw.WriteUInt16(kf.Frame);
                        bw.WriteByte((byte)kf.ValueType);

                        byte curveFlags = (byte)kf.Interpolation;
                        if (kf.StartSlopeAdjust) curveFlags |= 0x04;
                        if (kf.EndSlopeAdjust) curveFlags |= 0x08;
                        bw.WriteByte(curveFlags);

                        if (isU8)
                        {
                            byte count = 0;
                            if ((kindEnable & 0x01) > 0) { bw.WriteByte(kf.R); count++; }
                            if ((kindEnable & 0x02) > 0) { bw.WriteByte(kf.G); count++; }
                            if ((kindEnable & 0x04) > 0) { bw.WriteByte(kf.B); count++; }
                            if (count == 0) bw.WriteByte(kf.Val);
                        }
                        else
                        {
                            bw.WriteSingle(kf.Value);
                            if (kf.Interpolation == BREFF.KeyCurveType.Hermite)
                            {
                                bw.WriteSingle(kf.InSlope);
                                bw.WriteSingle(kf.OutSlope);
                            }
                        }
                    }

                    _node.AnimationItem.KeyTableData = ms.ToArray();
                }
                finally
                {
                    bw.Close();
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }

    public class KeyframeUIEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            var node = context.Instance as AnimationDataNode;

            if (svc != null && node != null && node.Format == BREFF.AnimationFormat.Keyed)
            {
                var parentForm = Form.ActiveForm;

                var form = new KeyframeEditorForm(node);
                form.MdiParent = parentForm;
                form.Show();
            }

            return value;
        }
    }
}
