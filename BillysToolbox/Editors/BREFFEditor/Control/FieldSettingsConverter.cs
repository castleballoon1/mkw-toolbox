using System.ComponentModel;
using static kartlib.Serial.BREFF;

namespace ParticleEditor.Control
{
    public class FieldSettingsConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            var settings = value as FieldSettings;
            if (settings == null) return base.GetProperties(context, value, attributes);

            if (!settings.IsValidField)
                return new PropertyDescriptorCollection(new PropertyDescriptor[0]);

            var allProps = TypeDescriptor.GetProperties(settings, attributes);
            var visibleProps = new List<PropertyDescriptor>();

            visibleProps.Add(allProps["FieldType"]);
            visibleProps.Add(allProps["Space"]);
            visibleProps.Add(allProps["AddTarget"]);
            visibleProps.Add(allProps["Options"]);

            switch (settings.FieldType)
            {
                case AnimTargetField.FieldGravity:
                    visibleProps.Add(allProps["Power"]);
                    visibleProps.Add(allProps["RotationX"]);
                    visibleProps.Add(allProps["RotationY"]);
                    visibleProps.Add(allProps["RotationZ"]);
                    break;
                case AnimTargetField.FieldSpeed:
                    visibleProps.Add(allProps["Speed"]);
                    break;
                case AnimTargetField.FieldMagnet:
                    visibleProps.Add(allProps["Power"]);
                    visibleProps.Add(allProps["TranslationX"]);
                    visibleProps.Add(allProps["TranslationY"]);
                    visibleProps.Add(allProps["TranslationZ"]);
                    break;
                case AnimTargetField.FieldNewton:
                    visibleProps.Add(allProps["Power"]);
                    visibleProps.Add(allProps["RefDistance"]);
                    visibleProps.Add(allProps["TranslationX"]);
                    visibleProps.Add(allProps["TranslationY"]);
                    visibleProps.Add(allProps["TranslationZ"]);
                    break;
                case AnimTargetField.FieldVortex:
                    visibleProps.Add(allProps["InnerSpeed"]);
                    visibleProps.Add(allProps["OuterSpeed"]);
                    visibleProps.Add(allProps["Distance"]);
                    visibleProps.Add(allProps["TranslationX"]);
                    visibleProps.Add(allProps["TranslationY"]);
                    visibleProps.Add(allProps["TranslationZ"]);
                    break;
                case AnimTargetField.FieldSpin:
                    visibleProps.Add(allProps["Speed"]);
                    visibleProps.Add(allProps["RotationX"]);
                    visibleProps.Add(allProps["RotationY"]);
                    visibleProps.Add(allProps["RotationZ"]);
                    break;
                case AnimTargetField.FieldRandom:
                    visibleProps.Add(allProps["Power"]);
                    visibleProps.Add(allProps["Diffusion"]);
                    break;
                case AnimTargetField.FieldTail:
                    visibleProps.Add(allProps["Power"]);
                    break;
            }

            return new PropertyDescriptorCollection(visibleProps.ToArray());
        }

        public override bool GetPropertiesSupported(ITypeDescriptorContext context) => true;
    }
}