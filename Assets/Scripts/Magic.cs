using System;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;

namespace Hicarm
{
    [System.Serializable]
    public struct Magic
    {
        [Tooltip("- Répulsion Désordre\n+ Attraction Ordre")] [SerializeField]
        public float Sens;

        public float SensPower => Mathf.Abs(Sens);

        [Tooltip("- Masse Matière\n+ Mouvement Esprit")] [SerializeField]
        public float Fond;

        public float FondPower => Mathf.Abs(Fond);

        [SerializeField] [Tooltip("- Intra Âme\n+ Extra Vie")]
        public float Forme;

        [HorizontalGroup] public float FormePower => Mathf.Abs(Forme);

        public Magic(float sens = 0, float fond = 0, float forme = 0) : this()
        {
            Sens = sens;
            Fond = fond;
            Forme = forme;
            CalculatePurity();
        }

        public float Power => SensPower + FondPower + FormePower;

        internal Vector3 ToVector3 => new Vector3(Sens, Fond, Forme);

        [ShowInInspector] public MagicElement Element { get; private set; }

        [ShowInInspector] public float Purity { get; private set; }

        internal void CalculatePurity()
        {
            MagicElement element = MagicElement.Elements[0];
            var purity = Magic.Dist(element.magic, this);
            for (var i = 1; i < MagicElement.Elements.Count; i++)
            {
                var newElement = MagicElement.Elements[i];
                if (newElement.name.StartsWith("#"))
                    continue;

                var newPurity = Magic.Dist(newElement.magic, this);
                if (newPurity < purity)
                {
                    element = newElement;
                    purity = newPurity;
                }
            }

            Purity = purity;
            Element = element;
        }

        public static Magic operator +(Magic a, Magic b)
        {
            return new Magic(a.Sens + b.Sens, a.Fond + b.Fond, a.Forme + b.Forme);
        }

        public static Magic operator *(float a, Magic b)
        {
            return new Magic(a * b.Sens, a * b.Fond, a * b.Forme);
        }

        public static float Dist(Magic a, Magic b)
        {
            return Vector3.Distance(a.ToVector3, b.ToVector3);
        }
    }
}