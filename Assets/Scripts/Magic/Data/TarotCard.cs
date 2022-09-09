using System.Collections.Generic;
using Hicarm.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Hicarm
{
    [CreateAssetMenu(menuName = "Tarot", fileName = "Data/Tarot")]
    public class TarotCard : ScriptableObject
    {
        public int number;
        public string symbol;
        public string concept;
        [Sirenix.OdinInspector.PreviewField] public Texture rune;
        public string son;
        public string colorName;

        [ShowInInspector]
        public Color Color =>
            new Color((element.sens + 1) / 2f, (element.forme + 1) / 2f, (element.fond + 1) / 2f);

        public Magic.Magic element;
        public string      quality;
        public string      @default;
        public string      biome;
        public string      place;
        public string      @object;
        public string      god;
        public string      plant;
        public string      equipement;
        public string      accesory;
        public string      weapon;
        public string      precious;
        public string      instrument;
        public string      technik;
        public string      species;
        public string      role;

        [SerializeField]
        internal static List<TarotCard> List;

        private void OnValidate()
        {
            if (List == null)
                List = new List<TarotCard>();

            if (!List.Contains(this))
            {
                List.Add(this);
            }
        }
    }
}