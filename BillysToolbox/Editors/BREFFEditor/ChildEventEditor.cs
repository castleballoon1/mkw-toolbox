using System.ComponentModel;
using kartlib.Serial;
using ParticleEditor.Control;

namespace BillysToolbox.Editors.BREFFEditor
{
    internal partial class ChildEventEditor : Form
    {
        private AnimationDataNode _node;
        private BindingList<ChildEvent> _events;

        public ChildEventEditor(AnimationDataNode node)
        {
            InitializeComponent();
            _node = node;
            _events = new BindingList<ChildEvent>();

            LoadEvents();

            dataGridView1.DataSource = _events;
            if (dataGridView1.Columns.Contains("ValueType"))
            {
                int colIndex = dataGridView1.Columns["ValueType"].Index;
                dataGridView1.Columns.RemoveAt(colIndex);

                var valueTypeColumn = new DataGridViewComboBoxColumn
                {
                    DataPropertyName = "ValueType",
                    HeaderText = "ValueType",
                    Name = "ValueType",
                    DataSource = Enum.GetValues(typeof(BREFF.KeyType)),
                    FlatStyle = FlatStyle.Flat
                };

                dataGridView1.Columns.Insert(colIndex, valueTypeColumn);
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            btnSave.Click += BtnSave_Click;
        }

        private void LoadEvents()
        {
            byte[] data = _node.AnimationItem.KeyTableData;
            if (data == null || data.Length < 4) return;

            using (var ms = new MemoryStream(data))
            using (var br = new BinaryReader(ms))
            {
                ushort entryCount = BitConverter.IsLittleEndian ?
                    System.Buffers.Binary.BinaryPrimitives.ReverseEndianness(br.ReadUInt16()) : br.ReadUInt16();
                br.ReadUInt16(); // Padding

                for (int i = 0; i < entryCount; i++)
                {
                    _events.Add(new ChildEvent
                    {
                        Frame = BitConverter.IsLittleEndian ? System.Buffers.Binary.BinaryPrimitives.ReverseEndianness(br.ReadUInt16()) : br.ReadUInt16(),
                        ValueType = (BREFF.KeyType)br.ReadByte(),
                        CurveFlags = br.ReadByte(),
                        NameIndex = BitConverter.IsLittleEndian ? System.Buffers.Binary.BinaryPrimitives.ReverseEndianness(br.ReadUInt16()) : br.ReadUInt16(),
                        SpeedModifier = br.ReadByte(),
                        ScaleModifier = br.ReadByte(),
                        AlphaModifier = br.ReadByte(),
                        ColorModifier = br.ReadByte(),
                        RenderPriority = br.ReadByte(),
                        ChildFlags = br.ReadByte()
                    });
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            using (var ms = new MemoryStream())
            using (var bw = new EndianWriter(ms, Endianness.BigEndian))
            {
                bw.WriteUInt16((ushort)_events.Count);
                bw.WriteUInt16(0); // Padding

                foreach (var ev in _events)
                {
                    bw.WriteUInt16(ev.Frame);
                    bw.WriteByte((byte)ev.ValueType);
                    bw.WriteByte(ev.CurveFlags);
                    bw.WriteUInt16(ev.NameIndex);
                    bw.WriteByte(ev.SpeedModifier);
                    bw.WriteByte(ev.ScaleModifier);
                    bw.WriteByte(ev.AlphaModifier);
                    bw.WriteByte(ev.ColorModifier);
                    bw.WriteByte(ev.RenderPriority);
                    bw.WriteByte(ev.ChildFlags);
                }

                _node.AnimationItem.KeyTableData = ms.ToArray();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}