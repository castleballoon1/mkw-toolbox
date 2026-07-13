using kartlib.Serial;
using System.ComponentModel;
using System.Drawing.Design;
using static kartlib.Serial.BREFF;

namespace ParticleEditor.Control
{
    internal class AnimationDataNode : DataNode
    {
        internal BREFF._Animation AnimationItem;

        [Category("Animation Data"), Description("Launch the dedicated editor for timeline Keyframes.")]
        [Editor(typeof(KeyframeUIEditor), typeof(UITypeEditor))]
        public string EditKeyframes
        {
            get
            {
                if (CurveFlag == BREFF.AnimType.Child || CurveFlag == BREFF.AnimType.Field)
                    return "N/A";

                return "...";
            }
            set { }
        }

        [Category("Animation Data"), Description("Environmental physics forces. This menu is only valid if CurveFlag is set to 'Field'.")]
        public FieldSettings PhysicsField
        {
            get
            {
                return new FieldSettings(AnimationItem);
            }
        }

        [Category("Animation Data"), Description("Launch the dedicated editor for Child Spawn Events.")]
        [Editor(typeof(ChildEventUIEditor), typeof(UITypeEditor))]
        public string ChildEvents
        {
            get
            {
                return CurveFlag == BREFF.AnimType.Child ? "..." : "N/A";
            }
            set { }
        }

        [Category("General Info"), Description("Changes the data format between raw pre-calculated frames (Baked) or timeline paths (Keyed).")]
        public BREFF.AnimationFormat Format
        {
            get { return (BREFF.AnimationFormat)AnimationItem.Identifier; }
            set { AnimationItem.Identifier = (byte)value; }
        }

        [Category("Configuration"), Description("The raw byte index of the animation target register.")]
        public byte KindType
        {
            get { return AnimationItem.KindType; }
            set { AnimationItem.KindType = value; }
        }

        [Category("Configuration"), Description("Derived hardware target name based on the broad curve settings.")]
        public string AnimationTarget
        {
            get
            {
                if (AnimationItem.CurveFlag == BREFF.AnimType.ParticleU8)
                {
                    switch (AnimationItem.KindType)
                    {
                        case 0: return "Color1Primary";
                        case 3: return "Alpha1Primary";
                        case 4: return "Color1Secondary";
                        case 7: return "Alpha1Secondary";
                        case 8: return "Color2Primary";
                        case 11: return "Alpha2Primary";
                        default: return $"Unknown U8 Register ({AnimationItem.KindType})";
                    }
                }
                return AnimationItem.CurveFlag.ToString();
            }
        }

        [Category("Configuration"), Description("The broad target category of the animation.")]
        public BREFF.AnimType CurveFlag
        {
            get { return AnimationItem.CurveFlag; }
            set { AnimationItem.CurveFlag = value; }
        }

        [Category("Active Channels"), Description("Enables animation calculations for the X-axis (Vectors) or the Red channel (Colors).")]
        public bool AnimateX_Red
        {
            get { return (AnimationItem.KindEnable & 0x01) > 0; }
            set
            {
                if (value) AnimationItem.KindEnable |= 0x01;
                else AnimationItem.KindEnable &= 0xFE;
            }
        }

        [Category("Active Channels"), Description("Enables animation calculations for the Y-axis (Vectors) or the Green channel (Colors).")]
        public bool AnimateY_Green
        {
            get { return (AnimationItem.KindEnable & 0x02) > 0; }
            set
            {
                if (value) AnimationItem.KindEnable |= 0x02;
                else AnimationItem.KindEnable &= 0xFD;
            }
        }

        [Category("Active Channels"), Description("Enables animation calculations for the Z-axis (Vectors) or the Blue channel (Colors).")]
        public bool AnimateZ_Blue
        {
            get { return (AnimationItem.KindEnable & 0x04) > 0; }
            set
            {
                if (value) AnimationItem.KindEnable |= 0x04;
                else AnimationItem.KindEnable &= 0xFB;
            }
        }

        [Category("Process Flags"), Description("Synchronizes the animation's random generation seed changes.")]
        public bool SyncRandomSeed
        {
            get { return (AnimationItem.ProcessFlag & (1 << 2)) > 0; }
            set
            {
                if (value) AnimationItem.ProcessFlag |= (1 << 2);
                else AnimationItem.ProcessFlag &= 0xFB;
            }
        }

        [Category("Process Flags"), Description("Forces the animation processing loop to freeze completely.")]
        public bool IsStopped
        {
            get { return (AnimationItem.ProcessFlag & (1 << 3)) > 0; }
            set
            {
                if (value) AnimationItem.ProcessFlag |= (1 << 3);
                else AnimationItem.ProcessFlag &= 0xF7;
            }
        }

        [Category("Process Flags"), Description("Forces calculations to execute inside Emitter Time scales rather than global particle ticks.")]
        public bool UseEmitterTiming
        {
            get { return (AnimationItem.ProcessFlag & (1 << 4)) > 0; }
            set
            {
                if (value) AnimationItem.ProcessFlag |= (1 << 4);
                else AnimationItem.ProcessFlag &= 0xEF;
            }
        }

        [Category("Process Flags"), Description("Forces the timeline to loop indefinitely.")]
        public bool LoopInfinitely
        {
            get { return (AnimationItem.ProcessFlag & (1 << 5)) > 0; }
            set
            {
                if (value) AnimationItem.ProcessFlag |= (1 << 5);
                else AnimationItem.ProcessFlag &= 0xDF;
            }
        }

        [Category("Process Flags"), Description("Toggles repeating loop style if looping logic is actively applied.")]
        public bool LoopByRepeating
        {
            get { return (AnimationItem.ProcessFlag & (1 << 6)) > 0; }
            set
            {
                if (value) AnimationItem.ProcessFlag |= (1 << 6);
                else AnimationItem.ProcessFlag &= 0xBF;
            }
        }

        [Category("Process Flags"), Description("Performs timeline expanding and contraction warping tailored directly to the parent asset lifetime metrics.")]
        public bool EnableLifetimeFitting
        {
            get { return (AnimationItem.ProcessFlag & (1 << 7)) > 0; }
            set
            {
                if (value) AnimationItem.ProcessFlag |= (1 << 7);
                else AnimationItem.ProcessFlag &= 0x7F;
            }
        }

        [Category("Playback")]
        public byte LoopCount
        {
            get { return AnimationItem.LoopCount; }
            set { AnimationItem.LoopCount = value; }
        }

        [Category("Playback")]
        public ushort FrameCount
        {
            get { return AnimationItem.FrameCount; }
            set { AnimationItem.FrameCount = value; }
        }

        [Category("Playback")]
        public ushort RandomSeed
        {
            get { return AnimationItem.RandomSeed; }
            set { AnimationItem.RandomSeed = value; }
        }

        public AnimationDataNode(BREFF._Animation animItem, string nodeName) : base(nodeName)
        {
            this.AnimationItem = animItem;
            SetImage("page");
        }
    }

    [TypeConverter(typeof(FieldSettingsConverter))]
    public class FieldSettings
    {
        private kartlib.Serial.BREFF._Animation _anim;

        public FieldSettings(kartlib.Serial.BREFF._Animation anim)
        {
            _anim = anim;
            if (_anim.InfoTableData == null || _anim.InfoTableData.Length < 4)
            {
                _anim.InfoTableData = new byte[4];
            }
        }

        [Browsable(false)]
        public bool IsValidField => _anim.CurveFlag == BREFF.AnimType.Field;

        [Category("Configuration"), Description("The specific type of physics field applied.")]
        [RefreshProperties(RefreshProperties.All)]
        public AnimTargetField FieldType
        {
            get => (AnimTargetField)_anim.KindType;
            set => _anim.KindType = (byte)value;
        }

        [Category("Configuration"), Description("0 = Local, 1 = Global, 2 = ParticleManager")]
        public byte Space { get => _anim.InfoTableData[0]; set => _anim.InfoTableData[0] = value; }

        [Category("Configuration"), Description("0 = Velocity, 1 = Position")]
        public byte AddTarget { get => _anim.InfoTableData[1]; set => _anim.InfoTableData[1] = value; }

        [Category("Configuration"), Description("Bitmask for randomized calculation behaviors.")]
        public byte Options { get => _anim.InfoTableData[2]; set => _anim.InfoTableData[2] = value; }

        private float GetFloat(int offset)
        {
            if (offset + 4 > _anim.InfoTableData.Length) return 0f;
            byte[] sub = new byte[4];
            Array.Copy(_anim.InfoTableData, offset, sub, 0, 4);
            if (BitConverter.IsLittleEndian) Array.Reverse(sub);
            return BitConverter.ToSingle(sub, 0);
        }

        private void SetFloat(int offset, float value)
        {
            if (offset + 4 > _anim.InfoTableData.Length)
            {
                byte[] tempArray = _anim.InfoTableData;
                Array.Resize(ref tempArray, offset + 4);
                _anim.InfoTableData = tempArray;
            }

            byte[] sub = BitConverter.GetBytes(value);
            if (BitConverter.IsLittleEndian) Array.Reverse(sub);
            Array.Copy(sub, 0, _anim.InfoTableData, offset, 4);
        }

        [Category("Math Parameters")] public float Power { get => GetFloat(4); set => SetFloat(4, value); }
        [Category("Math Parameters")] public float Speed { get => GetFloat(4); set => SetFloat(4, value); }
        [Category("Math Parameters")] public float InnerSpeed { get => GetFloat(4); set => SetFloat(4, value); }

        [Category("Math Parameters")] public float RotationX { get => GetFloat(8); set => SetFloat(8, value); }
        [Category("Math Parameters")] public float OuterSpeed { get => GetFloat(8); set => SetFloat(8, value); }
        [Category("Math Parameters")] public float Diffusion { get => GetFloat(8); set => SetFloat(8, value); }
        [Category("Math Parameters")] public float RefDistance { get => GetFloat(8); set => SetFloat(8, value); }

        [Category("Math Parameters")] public float RotationY { get => GetFloat(12); set => SetFloat(12, value); }
        [Category("Math Parameters")] public float Distance { get => GetFloat(12); set => SetFloat(12, value); }

        [Category("Math Parameters")] public float RotationZ { get => GetFloat(16); set => SetFloat(16, value); }

        [Category("Math Parameters")]
        public float TranslationX
        {
            get
            {
                if (FieldType == AnimTargetField.FieldMagnet) return GetFloat(8);
                if (FieldType == AnimTargetField.FieldNewton) return GetFloat(12);
                if (FieldType == AnimTargetField.FieldVortex) return GetFloat(16);
                return 0f;
            }
            set
            {
                if (FieldType == AnimTargetField.FieldMagnet) SetFloat(8, value);
                else if (FieldType == AnimTargetField.FieldNewton) SetFloat(12, value);
                else if (FieldType == AnimTargetField.FieldVortex) SetFloat(16, value);
            }
        }

        [Category("Math Parameters")]
        public float TranslationY
        {
            get
            {
                if (FieldType == AnimTargetField.FieldMagnet) return GetFloat(12);
                if (FieldType == AnimTargetField.FieldNewton) return GetFloat(16);
                if (FieldType == AnimTargetField.FieldVortex) return GetFloat(20);
                return 0f;
            }
            set
            {
                if (FieldType == AnimTargetField.FieldMagnet) SetFloat(12, value);
                else if (FieldType == AnimTargetField.FieldNewton) SetFloat(16, value);
                else if (FieldType == AnimTargetField.FieldVortex) SetFloat(20, value);
            }
        }

        [Category("Math Parameters")]
        public float TranslationZ
        {
            get
            {
                if (FieldType == AnimTargetField.FieldMagnet) return GetFloat(16);
                if (FieldType == AnimTargetField.FieldNewton) return GetFloat(20);
                if (FieldType == AnimTargetField.FieldVortex) return GetFloat(24);
                return 0f;
            }
            set
            {
                if (FieldType == AnimTargetField.FieldMagnet) SetFloat(16, value);
                else if (FieldType == AnimTargetField.FieldNewton) SetFloat(20, value);
                else if (FieldType == AnimTargetField.FieldVortex) SetFloat(24, value);
            }
        }

        public override string ToString()
        {
            return IsValidField ? "..." : "N/A";
        }
    }

    public class KeyframeEntry
    {
        public ushort Frame { get; set; }
        public BREFF.KeyType ValueType { get; set; } = BREFF.KeyType.Fixed;
        public BREFF.KeyCurveType Interpolation { get; set; } = BREFF.KeyCurveType.Linear;

        public bool StartSlopeAdjust { get; set; }
        public bool EndSlopeAdjust { get; set; }

        public float Value { get; set; }
        public float InSlope { get; set; }
        public float OutSlope { get; set; }

        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }
        public byte Val { get; set; }

        public KeyframeEntry() { }
    }
}