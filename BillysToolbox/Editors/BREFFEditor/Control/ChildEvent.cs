using System.ComponentModel;
using kartlib.Serial;

namespace ParticleEditor.Control
{
    public class ChildEvent
    {
        public ushort Frame { get; set; }
        public BREFF.KeyType ValueType { get; set; } = BREFF.KeyType.Fixed;
        public byte CurveFlags { get; set; } = 0;

        [Description("The index of the child emitter's name in the TargetNames string table.")]
        public ushort NameIndex { get; set; }

        public byte SpeedModifier { get; set; }
        public byte ScaleModifier { get; set; }
        public byte AlphaModifier { get; set; }
        public byte ColorModifier { get; set; }
        public byte RenderPriority { get; set; } = 128;
        public byte ChildFlags { get; set; }

        public ChildEvent() { }
    }
}