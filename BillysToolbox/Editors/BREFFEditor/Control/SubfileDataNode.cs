using kartlib.Serial;
using System.ComponentModel;

namespace ParticleEditor.Control
{
    internal class SubfileDataNode : DataNode
    {
        BREFF._TableItem Item;

        [Category("Info")]
        public string Name
        {
            get { return Item.Name; }
        }

        [Category("Info")]
        public uint DataOffset
        {
            get { return Item.DataOffset; }
        }

        [Category("Info")]
        public uint DataLength
        {
            get { return Item.DataSize;}
        }

        public SubfileDataNode(BREFF._TableItem item) : base(item.Name)
        {
            this.Item = item;
            SetImage("page");

            // Add Emitter
            AddChild(new EmitterDataNode(item.Emitter));

            // Add Particle
            AddChild(new ParticleDataNode(item.Particle));

            if (item.AnimationTable != null && item.AnimationTable.ParticleAnimations.Count > 0)
            {
                DataNode particleAnimsFolder = new DataNode("Particle Animations");
                particleAnimsFolder.SetImage("folder");

                for (int i = 0; i < item.AnimationTable.ParticleAnimations.Count; i++)
                {
                    particleAnimsFolder.AddChild(new AnimationDataNode(
                        item.AnimationTable.ParticleAnimations[i],
                        $"Animation {i}"
                    ));
                }

                AddChild(particleAnimsFolder);
            }

            if (item.AnimationTable != null && item.AnimationTable.EmitterAnimations.Count > 0)
            {
                DataNode emitterAnimsFolder = new DataNode("Emitter Animations");
                emitterAnimsFolder.SetImage("folder");

                for (int i = 0; i < item.AnimationTable.EmitterAnimations.Count; i++)
                {
                    emitterAnimsFolder.AddChild(new AnimationDataNode(
                        item.AnimationTable.EmitterAnimations[i],
                        $"Animation {i}"
                    ));
                }

                AddChild(emitterAnimsFolder);
            }
        }
    }
}
