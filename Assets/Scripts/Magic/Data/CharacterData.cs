using System;
using UnityEngine;

namespace Hicarm.Data
{
    [CreateAssetMenu(fileName = "Character", menuName = "Data/Character", order = 0)]
    public class CharacterData : ScriptableObject
    {
        [SerializeField]
        private Carac force = Carac.Moyen;
        [SerializeField]
        private Carac agility = Carac.Moyen;
        [SerializeField]
        private Carac memory = Carac.Moyen;
        [SerializeField]
        private Carac imagination = Carac.Moyen;
        [SerializeField]
        private Carac perception = Carac.Moyen;
        [SerializeField]
        private Carac concentration = Carac.Moyen;
        [SerializeField, HideInInspector]
        private short forceBonus = 0;
        [SerializeField, HideInInspector]
        private short agilityBonus = 0;
        [SerializeField, HideInInspector]
        private short memoryBonus = 0;
        [SerializeField, HideInInspector]
        private short imaginationBonus = 0;
        [SerializeField, HideInInspector]
        private short perceptionBonus = 0;
        [SerializeField, HideInInspector]
        private short concentrationBonus = 0;

        public Carac Force         { get => force + forceBonus;                 set => force = value; }
        public Carac Agility       { get => agility + agilityBonus;             set => agility = value; }
        public Carac Memory        { get => memory + memoryBonus;               set => memory = value; }
        public Carac Imagination   { get => imagination + imaginationBonus;     set => imagination = value; }
        public Carac Perception    { get => perception + perceptionBonus;       set => perception = value; }
        public Carac Concentration { get => concentration + concentrationBonus; set => concentration = value; }
    }

    [Serializable]
    public struct Carac
    {
        [SerializeField]
        private ushort value;

        private Carac(ushort value)
        {
            this.value = value;
        }

        public static Carac Undefined = new Carac(0);
        public static Carac Handicap  = new Carac(1);
        public static Carac Faible    = new Carac(2);
        public static Carac Moyen     = new Carac(3);
        public static Carac Fort      = new Carac(4);
        public static Carac Avantage  = new Carac(5);

        public static Carac operator +(Carac carac, short modifier)
        {
            int    caracValue = carac.value + modifier;
            ushort value      = (ushort)Mathf.Min(Mathf.Max(caracValue, 1), 5);
            return new Carac(value);
        }
    }
}