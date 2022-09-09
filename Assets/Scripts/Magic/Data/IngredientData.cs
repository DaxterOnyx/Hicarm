using System.Collections.Generic;
using UnityEngine;

namespace Hicarm.Data
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "Data/Ingredient", order = 0)]
    public class IngredientData : ScriptableObject
    {
        [SerializeField]
        public static List<IngredientData> List;
        
        [SerializeField]
        public Magic.Magic magic;
        public float price;
        public Tag tag;
        public Texture image;
        [TextArea]
        public string descritpion;
        
        public enum Tag
        {
            Herbe,
            Racine,
            Fleur,
            Champignon,
            Mineral,
        }
        
        private void OnValidate()
        {
            if (List == null)
                List = new List<IngredientData>();
            
            if(!List.Contains(this))
                List.Add(this);
        }
    }
}