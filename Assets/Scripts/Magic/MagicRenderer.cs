using Hicarm;
using Hicarm.Data;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Magic
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
            Rune,
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

                    if (Rendered is Type.All or Type.Element)
                    {
                        DisplayMagic(element.name, element.magic, null);
                    }
                    else if (element.name.StartsWith("#"))
                    {
                        DisplayMagic(element.name, element.magic, null);
                    }
                }
            }

            if (Rendered is Type.All or Type.Ingredient)
            {
                if (IngredientData.List != null)
                {
                    var ingredients = IngredientData.List;
                    for (var i = 0; i < ingredients.Count; i++)
                    {
                        IngredientData ingredientData = ingredients[i];
                        while (ingredientData == null)
                        {
                            ingredients.RemoveAt(i);
                            ingredientData = ingredients[i];
                        }

                        DisplayMagic(ingredientData.name, ingredientData.magic, ingredientData.image);
                    }
                }
            }
            
            if (Rendered is Type.All or Type.Rune)
            {
                if (TarotCard.List != null)
                {
                    var cards = TarotCard.List;
                    for (var i = 0; i < cards.Count; i++)
                    {
                        var card = cards[i];
                        while (card == null)
                        {
                            cards.RemoveAt(i);
                            card = cards[i];
                        }

                        DisplayMagic(card.name, card.element, card.rune);
                    }
                }
            }
        }

        private void DisplayMagic(string name, global::Magic.Magic magic, Texture image)
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