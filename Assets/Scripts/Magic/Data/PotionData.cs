using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Hicarm.Data
{
    [CreateAssetMenu(fileName = "Potion", menuName = "Data/Potion", order = 0)]
    public class PotionData : ScriptableObject
    {
        [Sirenix.OdinInspector.ReadOnly, ShowInInspector] private Magic.Magic  magic;
        public                                                    Magic.Magic  Magic  => magic;
        public                                                    MagicElement Effect => magic.Element;

        [FormerlySerializedAs("Ingredients"),SerializeField] public List<Proportion> ingredients = new List<Proportion>();

        private void OnValidate()
        {
            magic = new Magic.Magic();
            foreach (var ingredient in ingredients)
            {
                if (ingredient.ingredientData != null)
                    magic += ingredient.proportion * 0.01f * ingredient.ingredientData.magic;
            }
        }

        [Serializable]
        public struct Proportion
        {
            [HorizontalGroup, HideLabel, SuffixLabel("g",true)] public float proportion;
            [FormerlySerializedAs("ingredient"),HorizontalGroup, HideLabel] public IngredientData ingredientData;
        }
    }
}