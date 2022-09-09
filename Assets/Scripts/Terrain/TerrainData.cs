using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Terrain
{
    public struct TerrainData
    {
        private List<ChunkData> chunks;
        public  bool            IsDefined = false;
        
        public TerrainData(int sizeX,int sizeY, int sizeZ)
        {
            chunks = new List<ChunkData>((int)(sizeX*sizeY*sizeZ));
            Magic.Magic magic;
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        var chunkData = new ChunkData();
                        chunks.Add(chunkData);
                    }
                }
            }

            IsDefined = true;
        }
    }

}