using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Hicarm
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Potion", order = 0)]
    public class Potion : ScriptableObject
    {
        [Sirenix.OdinInspector.ReadOnly, ShowInInspector] private Magic magic;
        public Magic Magic => magic;
        public MagicElement Effect => magic.Element;

        [SerializeField] public List<Proportion> Ingredients = new List<Proportion>();

        private void OnValidate()
        {
            magic = new Magic();
            foreach (var ingredient in Ingredients)
            {
                if (ingredient.ingredient != null)
                    magic += ingredient.proportion * 0.01f * ingredient.ingredient.magic;
            }
        }

        [Serializable]
        public struct Proportion
        {
            [HorizontalGroup, HideLabel, SuffixLabel("g",true)] public float proportion;
            [HorizontalGroup, HideLabel] public Ingredient ingredient;
        }
    }
}