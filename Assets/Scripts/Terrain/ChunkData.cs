using UnityEngine;

namespace Terrain
{
    public struct ChunkData
    {
        static private int lastId = -1;
        
        public int         id;
        public Magic.Magic magic;

        public ChunkData(Magic.Magic average = new Magic.Magic(), float random = 0.1f) : this()
        {
            id    = ++lastId;
            magic = average + Random.insideUnitSphere * random;
        }
    }
}