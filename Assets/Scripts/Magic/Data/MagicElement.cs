using System.Collections.Generic;
using UnityEngine;

namespace Hicarm.Data
{
    [CreateAssetMenu(menuName = "MagicElement", fileName = "Data/MagicElement")]
    public class MagicElement : ScriptableObject
    {
        public Magic.Magic magic;

        [SerializeField]
        internal static List<MagicElement> Elements;

        private void OnValidate()
        {
            if (Elements == null)
                Elements = new List<MagicElement>();
            
            if (!Elements.Contains(this))
            {
                Elements.Add(this);
            }
        }
    }
}