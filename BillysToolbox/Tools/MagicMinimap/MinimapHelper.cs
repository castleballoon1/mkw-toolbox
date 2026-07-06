// This class uses Wiimm's algorithm for calculating the minimap borders based on the model's vertices.
// More information can be found here: https://szs.wiimm.de/wszst/cmd-minimap.html#auto

using kartlib.Serial;
using System.Numerics;

namespace BillysToolbox.Tools.MagicMinimap
{
    public static class MinimapHelper
    {
        public struct MinimapBorders
        {
            public float MinX, MaxX;
            public float MinZ, MaxZ;
            public float TransY;
        }

        public static MinimapBorders CalculateAutoBorders(IEnumerable<Vector3> mdlVertices)
        {
            float minX = float.MaxValue, maxX = float.MinValue;
            float minY = float.MaxValue, maxY = float.MinValue;
            float minZ = float.MaxValue, maxZ = float.MinValue;
            bool validVerticesFound = false;

            foreach (var v in mdlVertices)
            {
                if (float.IsNaN(v.X) || float.IsNaN(v.Y) || float.IsNaN(v.Z))
                    continue;

                if (Math.Abs(v.X) > 10000000f || Math.Abs(v.Y) > 10000000f || Math.Abs(v.Z) > 10000000f)
                    continue;

                minX = Math.Min(minX, v.X);
                maxX = Math.Max(maxX, v.X);
                minY = Math.Min(minY, v.Y);
                maxY = Math.Max(maxY, v.Y);
                minZ = Math.Min(minZ, v.Z);
                maxZ = Math.Max(maxZ, v.Z);

                validVerticesFound = true;
            }

            if (!validVerticesFound)
                throw new Exception("No valid vertices found to calculate minimap borders.");

            if (Math.Abs(minX) >= 1000000f || Math.Abs(maxX) >= 1000000f ||
                Math.Abs(minZ) >= 1000000f || Math.Abs(maxZ) >= 1000000f)
            {
                throw new Exception("Vertex coordinates are too large for automatic adjustment (Exceeds 10^6).");
            }

            float widthX = maxX - minX;
            float widthZ = maxZ - minZ;

            float padX = widthX * 0.04f;
            float padZ = widthZ * 0.04f;

            minX -= padX;
            maxX += padX;
            minZ -= padZ;
            maxZ += padZ;

            minX -= 100f;
            maxX += 100f;
            minZ -= 100f;
            maxZ += 100f;

            float transY = 0.0f;
            if (maxY > 49000.0f)
            {
                transY = maxY;
            }

            return new MinimapBorders
            {
                MinX = minX,
                MaxX = maxX,
                MinZ = minZ,
                MaxZ = maxZ,
                TransY = transY
            };
        }

        public static byte[] ExecuteMinimapAlignment(byte[] brresFileBytes)
        {
            BRRES brres = new BRRES(brresFileBytes, "map_model.brres");

            MDL0 mapMdl = brres.Subfiles.FirstOrDefault(s => s.Magic == "MDL0")?.mdl0;
            if (mapMdl == null) throw new Exception("No MDL0 found in this BRRES.");

            List<Vector3> allVertices = new List<Vector3>();
            foreach (var group in mapMdl.VertexGroups)
            {
                allVertices.AddRange(group.Vertices);
            }

            var borders = CalculateAutoBorders(allVertices);

            var posLD = mapMdl.Bones.FirstOrDefault(b => b.Name == "posLD");
            var posRU = mapMdl.Bones.FirstOrDefault(b => b.Name == "posRU");

            if (posLD == null || posRU == null)
                throw new Exception("map_model is missing posLD or posRU bones.");

            byte[] outputBytes = (byte[])brresFileBytes.Clone();

            using (MemoryStream ms = new MemoryStream(outputBytes))
            using (EndianWriter writer = new EndianWriter(ms, Endianness.BigEndian))
            {
                ApplyBoneData(writer, posLD, borders.MinX, borders.MinZ, borders.TransY);
                ApplyBoneData(writer, posRU, borders.MaxX, borders.MaxZ, borders.TransY);
            }

            return outputBytes;
        }

        private static void ApplyBoneData(EndianWriter writer, MDL0._Bone bone, float targetX, float targetZ, float targetY)
        {
            writer.Position = bone.FlagsOffset;
            writer.WriteUInt32(0x31F);

            writer.Position = bone.ScaleOffset;
            writer.WriteSingles(new float[] { 1.0f, 1.0f, 1.0f });

            writer.Position = bone.RotationOffset;
            writer.WriteSingles(new float[] { 0.0f, 0.0f, 0.0f });

            writer.Position = bone.TranslationOffset;
            writer.WriteSingles(new float[] { targetX, targetY, targetZ });

            writer.Position = bone.BoxMinOffset;
            writer.WriteSingles(new float[] { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f });
        }
    }
}