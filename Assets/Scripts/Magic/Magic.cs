﻿using Hicarm.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Magic
{
    [System.Serializable]
    public struct Magic
    {
        [FormerlySerializedAs("Change"), Tooltip("- Répulsion Désordre\n+ Attraction Ordre")] [SerializeField]
        public float sens;

        public float SensPower => Mathf.Abs(sens);

        [FormerlySerializedAs("Structure"), Tooltip("- Masse Matière\n+ Mouvement Esprit")] [SerializeField]
        public float fond;

        public float FondPower => Mathf.Abs(fond);

        [FormerlySerializedAs("Aspect"), SerializeField] [Tooltip("- Intra Âme\n+ Extra Vie")]
        public float forme;

        [HorizontalGroup] public float FormePower => Mathf.Abs(forme);

        public Magic(float sens = 0, float fond = 0, float forme = 0) : this()
        {
            this.sens  = sens;
            this.fond  = fond;
            this.forme = forme;
            CalculatePurity();
        }
        
        public Magic(Vector3 data) : this(data.x,data.y,data.z) {}
        
        public float Power => SensPower + FondPower + FormePower;

        public Color ToColor => new Color(sens + 0.5f, fond + .5f, forme + .5f, 0.5f);
        internal Vector3 ToVector3 => new Vector3(sens, fond, forme);

        [ShowInInspector] public MagicElement Element { get; private set; }

        [ShowInInspector] public float Purity { get; private set; }

        internal void CalculatePurity()
        {
            MagicElement element = MagicElement.Elements[0];
            var          purity  = Magic.Dist(element.magic, this);
            for (var i = 1; i < MagicElement.Elements.Count; i++)
            {
                var newElement = MagicElement.Elements[i];
                if (newElement.name.StartsWith("#"))
                    continue;

                var newPurity = Magic.Dist(newElement.magic, this);
                if (newPurity < purity)
                {
                    element = newElement;
                    purity  = newPurity;
                }
            }

            Purity  = purity;
            Element = element;
        }

        public static Magic operator +(Magic a, Magic b)
        {
            return new Magic(a.sens + b.sens, a.fond + b.fond, a.forme + b.forme);
        }
        public static Magic operator +(Magic a, Vector3 b)
        {
            return new Magic(a.sens + b.x, a.fond + b.y, a.forme + b.z);
        }

        public static Magic operator *(float a, Magic b)
        {
            return new Magic(a * b.sens, a * b.fond, a * b.forme);
        }

        public static float Dist(Magic a, Magic b)
        {
            return Vector3.Distance(a.ToVector3, b.ToVector3);
        }

    }
}