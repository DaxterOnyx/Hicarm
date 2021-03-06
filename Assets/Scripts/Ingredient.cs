using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Hicarm
{
    [CreateAssetMenu(fileName = "Ingredient", menuName = "Ingredient", order = 0)]
    public class Ingredient : ScriptableObject
    {
        [SerializeField]
        public static List<Ingredient> List;
        
        [SerializeField]
        public Magic magic;
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
                List = new List<Ingredient>();
            
            if(!List.Contains(this))
                List.Add(this);
        }
    }
}