using System.Numerics;

namespace kartlib.Serial
{
    public class MDL0
    {
        public class _Header
        {
            public UInt32 Magic;
            public UInt32 Size;
            public UInt32 Version;
            public Int32 ParentArchiveOffset;
            public Int32[] SectionOffsets;
            public Int32 NameOffset;

            public _Header(EndianReader reader)
            {
                Magic = reader.ReadUInt32();
                Size = reader.ReadUInt32();
                Version = reader.ReadUInt32();
                ParentArchiveOffset = reader.ReadInt32();

                // TODO: Verify Magic

                // Account for different versions
                List<Int32> tmpSectionOffset = new List<Int32>();
                tmpSectionOffset.AddRange(reader.ReadInt32s(6));

                if(Version >= 10)
                {
                    tmpSectionOffset.AddRange(reader.ReadInt32s(7));
                    if(Version >= 11)
                        tmpSectionOffset.Add(reader.ReadInt32());
                }
                else
                {
                    tmpSectionOffset.AddRange(reader.ReadInt32s(5));
                }

                SectionOffsets = tmpSectionOffset.ToArray();
                NameOffset = reader.ReadInt32();
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(Magic);
                writer.WriteUInt32(Size);
                writer.WriteUInt32(Version);
                writer.WriteInt32(ParentArchiveOffset);
                writer.WriteInt32s(SectionOffsets);
                writer.WriteInt32(NameOffset);
            }
        }

        public class _MDL0Header
        {
            public enum ScalingModeEnum : UInt32
            {
                Standard = 0x0,
                SoftImage = 0x1,
                Maya = 0x2
            }

            public enum TextureMatrixModeEnum : UInt32
            {
                Maya = 0x0,
                XSI = 0x1,
                Max = 0x2
            }

            public UInt32 HeaderLength;
            public Int32 FileHeaderOffset;
            public ScalingModeEnum ScalingMode;
            public TextureMatrixModeEnum TextureMatrixMode;
            public Int32 VertexCount;
            public Int32 FaceCount;
            public Int32 IntermediateFileOffset;
            public UInt32 MatrixCount;
            public Byte NormalizedMatrices;
            public Byte TextureMatrices;
            public Byte EnableBoundingBox;
            public Byte Reserved;
            public Int32 MatrixTableOffset;
            public float[] BoundingBoxMin;
            public float[] BoundingBoxMax;

            public _MDL0Header(EndianReader reader)
            {
                HeaderLength = reader.ReadUInt32();
                FileHeaderOffset = reader.ReadInt32();
                ScalingMode = (ScalingModeEnum)reader.ReadUInt32();
                TextureMatrixMode = (TextureMatrixModeEnum)reader.ReadUInt32();
                VertexCount = reader.ReadInt32();
                FaceCount = reader.ReadInt32();
                IntermediateFileOffset = reader.ReadInt32();
                MatrixCount = reader.ReadUInt32();
                NormalizedMatrices = reader.ReadByte();
                TextureMatrices = reader.ReadByte();
                EnableBoundingBox = reader.ReadByte();
                Reserved = reader.ReadByte();
                MatrixTableOffset = reader.ReadInt32();
                BoundingBoxMin = reader.ReadSingles(3);
                BoundingBoxMax = reader.ReadSingles(3);
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(HeaderLength);
                writer.WriteInt32(FileHeaderOffset);
                writer.WriteUInt32((UInt32)ScalingMode);
                writer.WriteUInt32((UInt32)TextureMatrixMode);
                writer.WriteInt32(VertexCount);
                writer.WriteInt32(FaceCount);
                writer.WriteInt32(IntermediateFileOffset);
                writer.WriteUInt32(MatrixCount);
                writer.WriteByte(NormalizedMatrices);
                writer.WriteByte(TextureMatrices);
                writer.WriteByte(EnableBoundingBox);
                writer.WriteByte(Reserved);
                writer.WriteInt32(MatrixTableOffset);
                writer.WriteSingles(BoundingBoxMin);
                writer.WriteSingles(BoundingBoxMax);
            }
        }

        public class _BoneLinkTable
        {
            public UInt32 EntryCount;
            public Int32[] Bones;

            public _BoneLinkTable(EndianReader reader)
            {
                EntryCount = reader.ReadUInt32();
                Bones = reader.ReadInt32s((int)EntryCount);
            }

            public void Write(EndianWriter writer)
            {
                writer.WriteUInt32(EntryCount);
                writer.WriteInt32s(Bones);
            }
        }

        public class _Code
        {
            public class _Node2
            {
                public UInt16 BoneIndex;
                public UInt16 ParentMatrixIndex;

                public _Node2(EndianReader reader)
                {
                    BoneIndex = reader.ReadUInt16();
                    ParentMatrixIndex = reader.ReadUInt16();
                }
            }

            public class _Node3
            {
                public class _Entry
                {
                    public UInt16 MatrixIndex;
                    public float Weight;

                    public _Entry(EndianReader reader)
                    {
                        MatrixIndex = reader.ReadUInt16();
                        Weight = reader.ReadSingle();
                    }
                }

                public UInt16 Index;
                public Byte EntryCount;
                public List<_Entry> Entries;

                public _Node3(EndianReader reader)
                {
                    Index = reader.ReadUInt16();
                    EntryCount = reader.ReadByte();
                    Entries = new List<_Entry>();

                    for(int i = 0; i < EntryCount; i++)
                        Entries.Add(new _Entry(reader));
                }
            }

            public class _Node4
            {
                public UInt16 MaterialIndex;
                public UInt16 ShapeIndex;
                public UInt16 BoneIndex;
                public UInt16 RenderPriority;

                public _Node4(EndianReader reader)
                {
                    MaterialIndex = reader.ReadUInt16();
                    ShapeIndex = reader.ReadUInt16();
                    BoneIndex = reader.ReadUInt16();
                    RenderPriority = reader.ReadUInt16();
                }

            }

            public class _Node5
            {
                public UInt16 MatrixIndex;
                public UInt16 BoneIndex;

                public _Node5(EndianReader reader)
                {
                    MatrixIndex = reader.ReadUInt16();
                    BoneIndex = reader.ReadUInt16();
                }
            }

            public Byte Value;
            public _Node2? Node2;
            public _Node3? Node3;
            public _Node4? Node4;
            public _Node5? Node5;

            public _Code(EndianReader reader, byte value)
            {
                Value = value;
                switch(Value)
                {
                    case 0:
                    case 1:
                        return;
                    case 2:
                        Node2 = new _Node2(reader);
                        break;
                    case 3:
                        Node3 = new _Node3(reader);
                        break;
                    case 4:
                        Node4 = new _Node4(reader);
                        break;
                    case 5:
                        Node5 = new _Node5(reader);
                        break;
                }
            }
        }

        public class _DrawList
        {
            public List<_Code> Codes;
            public string Name;

            public _DrawList(EndianReader reader, string name)
            {
                Name    = name;
                Codes   = new List<_Code>();

                Byte value = reader.ReadByte();
                while (value != 0x01)
                {
                    Codes.Add(new _Code(reader, value));
                    value = reader.ReadByte();
                }
            }
        }

        public class _VertexData
        {
            public List<Vector3> Vertices;

            public _VertexData(EndianReader reader, int globalDataOffset)
            {
                reader.Position = globalDataOffset;

                UInt32 length = reader.ReadUInt32();            // 0x00
                Int32 mdl0Offset = reader.ReadInt32();          // 0x04
                Int32 dataOffset = reader.ReadInt32();          // 0x08
                Int32 nameOffset = reader.ReadInt32();          // 0x0C
                UInt32 index = reader.ReadUInt32();             // 0x10

                UInt32 componentCount = reader.ReadUInt32();    // 0x14 (0 = XY, 1 = XYZ)
                UInt32 dataType = reader.ReadUInt32();          // 0x18 (0=U8, 1=S8, 2=U16, 3=S16, 4=Float)

                byte divisor = reader.ReadByte();               // 0x1C
                byte stride = reader.ReadByte();                // 0x1D
                UInt16 vertexCount = reader.ReadUInt16();       // 0x1E

                reader.Position = globalDataOffset + dataOffset;

                Vertices = new List<Vector3>();

                if (dataType == 4)
                {
                    for (int i = 0; i < vertexCount; i++)
                    {
                        float x = reader.ReadSingle();
                        float y = reader.ReadSingle();
                        float z = 0f;

                        if (componentCount == 1)
                        {
                            z = reader.ReadSingle();
                        }

                        Vertices.Add(new Vector3(x, y, z));
                    }
                }
                else
                {
                    throw new Exception($"Unsupported vertex data type: {dataType}. Only Float (4) is currently supported.");
                }
            }
        }

        public class _Bone
        {
            public string Name;
            public int AbsoluteDataPosition;

            public int FlagsOffset => AbsoluteDataPosition + 0x14;
            public int ScaleOffset => AbsoluteDataPosition + 0x20;
            public int RotationOffset => AbsoluteDataPosition + 0x2C;
            public int TranslationOffset => AbsoluteDataPosition + 0x38;
            public int BoxMinOffset => AbsoluteDataPosition + 0x44;
            public int BoxMaxOffset => AbsoluteDataPosition + 0x50;

            public _Bone(EndianReader reader, BRRES._IndexGroupEntry entry)
            {
                AbsoluteDataPosition = entry.GlobalDataOffset;

                int tempPos = reader.Position;
                reader.Position = entry.GlobalNameOffset - 4;
                Name = reader.ReadString(reader.ReadInt32());
                reader.Position = tempPos;
            }
        }

        /////////////////////////////////////////////////////
        /////////////////////////////////////////////////////

        public List<_Bone> Bones { get; set; }
        public List<_VertexData> VertexGroups { get; set; }

        public MDL0(EndianReader reader)
        {
            _Header header = new _Header(reader);
            _MDL0Header mdl0Header = new _MDL0Header(reader);
            _BoneLinkTable boneLinkTable = new _BoneLinkTable(reader);

            Bones = new List<_Bone>();
            VertexGroups = new List<_VertexData>();

            if (header.SectionOffsets[1] != 0)
            {
                reader.Position = header.SectionOffsets[1] - header.ParentArchiveOffset;
                BRRES._IndexGroup boneIndexGroup = new BRRES._IndexGroup(reader);

                for (int i = 1; i <= boneIndexGroup.EntryCount; i++)
                {
                    Bones.Add(new _Bone(reader, boneIndexGroup[i]));
                }
            }

            if (header.SectionOffsets[2] != 0)
            {
                reader.Position = header.SectionOffsets[2] - header.ParentArchiveOffset;
                BRRES._IndexGroup vertexIndexGroup = new BRRES._IndexGroup(reader);

                for (int i = 1; i <= vertexIndexGroup.EntryCount; i++)
                {
                    VertexGroups.Add(new _VertexData(reader, vertexIndexGroup[i].GlobalDataOffset));
                }
            }

            // Definition section
            reader.Position = header.SectionOffsets[0] - header.ParentArchiveOffset;
            BRRES._IndexGroup drawListIndexGroup = new BRRES._IndexGroup(reader);
            int tmpPosition = reader.Position;

            List<_DrawList> drawLists = new List<_DrawList>();
            for(int i = 1; i <= drawListIndexGroup.EntryCount; i++)
            {
                reader.Position = drawListIndexGroup[i].GlobalNameOffset - sizeof(Int32);
                string name = reader.ReadString(reader.ReadInt32());
                reader.Position = drawListIndexGroup[i].GlobalDataOffset;
                drawLists.Add(new _DrawList(reader, name));
            }

            reader.Position = tmpPosition;
        }
    }
}
