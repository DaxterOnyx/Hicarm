using Sirenix.OdinInspector;
using UnityEngine;

namespace Tween
{
    public class TweenTester : MonoBehaviour
    {
        public  float              start    = -10;
        public  float              end      = 10;
        public  float              duration = 10;
        public  TweenData.LerpType type;
        private float              v = 0;

        public SerializeReference t;
        [Button]
        private void test()
        {
            v.TweenIt(start, end, duration, type);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(new Vector3(v, 0, 0), 1);
            SerializeReference r = new SerializeReference();
            
        }
    }
}