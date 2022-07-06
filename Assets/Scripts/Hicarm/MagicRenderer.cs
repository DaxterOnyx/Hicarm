using Hicarm.Data;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Hicarm
{
    [ExecuteInEditMode]
    public class MagicRenderer : MonoBehaviour
    {
        public Type Rendered = Type.All;
        public Axis Ignored = Axis.None;

        [ShowInInspector, ReadOnly] private int nbElements;

        public enum Type
        {
            All,
            Ingredient,
            Element,
        }

        public enum Axis
        {
            Sens,
            Forme,
            Fond,
            Complex,
            Void,
            None
        }

        private void OnDrawGizmos()
        {
            nbElements = 0;
            if (MagicElement.Elements != null)
            {
                for (var i = 0; i < MagicElement.Elements.Count; i++)
                {
                    MagicElement element = MagicElement.Elements[i];
                    while (element == null)
                    {
                        MagicElement.Elements.RemoveAt(i);
                        element = MagicElement.Elements[i];
                    }

                    if (Rendered == Type.All || Rendered == Type.Element)
                    {
                        DisplayMagic(element.name, element.magic, null);
                    }
                    else if (element.name.StartsWith("#"))
                    {
                        DisplayMagic(element.name, element.magic, null);
                    }
                }
            }

            if (Rendered == Type.All || Rendered == Type.Ingredient)
            {
                if (Ingredient.List != null)
                {
                    var ingredients = Ingredient.List;
                    for (var i = 0; i < ingredients.Count; i++)
                    {
                        Ingredient ingredient = ingredients[i];
                        while (ingredient == null)
                        {
                            ingredients.RemoveAt(i);
                            ingredient = ingredients[i];
                        }

                        DisplayMagic(ingredient.name, ingredient.magic, ingredient.image);
                    }
                }
            }
        }

        private void DisplayMagic(string name, Magic magic, Texture image)
        {
            switch (Ignored)
            {
                case Axis.Fond when magic.fond != 0:
                case Axis.Sens when magic.sens != 0:
                case Axis.Forme when magic.forme != 0:
                case Axis.Complex when (magic.forme == 0 || magic.sens == 0 ||
                                        magic.fond == 0):
                case Axis.Void when magic.forme != 0 || magic.sens != 0 ||
                                    magic.fond != 0 || name.StartsWith("#"):
                    return;
            }

            Vector3 position = magic.ToVector3;
            if (image != null)
            {
                Gizmos.DrawIcon(position, image.name, false);
            }
            else
            {
                Gizmos.color = new Color(magic.SensPower, magic.FondPower, magic.FormePower, 0.5f);
                Gizmos.DrawSphere(position, 0.03f);
            }
            Handles.Label(position, name);
            if (!name.StartsWith("#"))
                nbElements++;
        }
    }
}