using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace Hicarm
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
                value.Sens = SirenixEditorFields.FloatField("Sens", value.Sens);
                value.Fond = SirenixEditorFields.FloatField("Fond", value.Fond);
                value.Forme =
                    SirenixEditorFields.FloatField(new GUIContent("Forme", "- Intra Âme\n+ Extra Vie"), value.Forme);
                GUIHelper.PopIndentLevel();

                this.ValueEntry.Values[i] = value;
            }
        }
    }
}