using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Hicarm
{
    [CreateAssetMenu(menuName = "MagicElement", fileName = "MagicElement")]
    public class MagicElement : ScriptableObject
    {
        public Magic magic;

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