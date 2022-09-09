using UnityEngine;

namespace Terrain
{
    public class Chunk : MonoBehaviour
    {
        private ChunkData data;
        
        public void OnDrawGizmos()
        {
            Gizmos.color = data.magic.ToColor;
            Gizmos.DrawCube(transform.position + Vector3.one / 2f, Vector3.one);
        }
    }
}