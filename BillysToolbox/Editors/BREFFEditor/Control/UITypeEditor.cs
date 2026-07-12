using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using BillysToolbox.Editors.BREFFEditor;

namespace ParticleEditor.Control
{
    public class ChildEventUIEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            var node = context.Instance as AnimationDataNode;

            if (svc != null && node != null && node.CurveFlag == kartlib.Serial.BREFF.AnimType.Child)
            {
                using (var form = new ChildEventEditor(node))
                {
                    svc.ShowDialog(form);
                }
            }
            return value;
        }
    }
}