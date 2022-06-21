using Sirenix.OdinInspector;
using UnityEngine;

namespace Hicarm
{
    [CreateAssetMenu(menuName = "Tarot", fileName = "Tarot")]
    public class TarotCard : ScriptableObject
    {
        public int Number;
        public string Name;
        public string Symbol;
        public string Concept;
        [Sirenix.OdinInspector.PreviewField] public Texture Rune;
        public string Son;
        public string ColorName;

        [ShowInInspector]
        public Color Color =>
            new Color((Element.Sens + 1) / 2f, (Element.Forme + 1) / 2f, (Element.Fond + 1) / 2f);

        public Magic Element;
        public string Quality;
        public string Default;
        public string Biome;
        public string Place;
        public string Object;
        public string God;
        public string Plant;
        public string Equipement;
        public string Accesory;
        public string Weapon;
        public string Precious;
        public string Instrument;
        public string Technik;
        public string Species;
        public string Role;
    }
}