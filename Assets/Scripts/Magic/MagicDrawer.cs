using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace Magic
{
    public class MagicDrawer : OdinValueDrawer<Magic>
    {
        protected override void DrawPropertyLayout(GUIContent label)
        {
            //base.DrawPropertyLayout(label);
            for (var i = 0; i < this.ValueEntry.Values.Count; i++)
            {
                var value = this.ValueEntry.Values[i];

                if (value.Element == null)
                {
                    value.CalculatePurity();
                }

                SirenixEditorGUI.Title($"{value.Element.name} {value.Purity}", "", (TextAlignment)TitleAlignments.Left,
                    false);
                GUIHelper.PushIndentLevel(1);
                value.sens = SirenixEditorFields.FloatField("Sens", value.sens);
                value.fond = SirenixEditorFields.FloatField("Fond", value.fond);
                value.forme =
                    SirenixEditorFields.FloatField(new GUIContent("Forme", "- Intra Âme\n+ Extra Vie"), value.forme);
                GUIHelper.PopIndentLevel();

                this.ValueEntry.Values[i] = value;
            }
        }
    }
}