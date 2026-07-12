using kartlib.Serial;
using System.ComponentModel;
using System.Drawing.Design;

namespace ParticleEditor.Control
{
    internal class AnimationDataNode : DataNode
    {
        internal BREFF._Animation AnimationItem;

        [Category("Animation Data"), Description("Launch the dedicated editor for Child Spawn Events.")]
        [Editor(typeof(ChildEventUIEditor), typeof(UITypeEditor))]
        public string ChildEvents
        {
            get
            {
                return CurveFlag == BREFF.AnimType.Child ? "(Click to Edit Child Events)" : "N/A";
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
}