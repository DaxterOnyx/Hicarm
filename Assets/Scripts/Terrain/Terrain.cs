using System;
using UnityEngine;

namespace Terrain
{
    public class Terrain : MonoBehaviour
    {
        public TerrainData data;

        private void Start()
        {
            if (!data.IsDefined)
            {
                data = new TerrainData(100,100,100);
            }
        }

        private void Update()
        {
            // TODO MOVE TerrainData in object
        }
    }
}