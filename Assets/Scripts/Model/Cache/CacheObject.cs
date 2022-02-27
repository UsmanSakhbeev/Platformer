using System;
using UnityEngine;

namespace Platformer
{
    [Serializable]
    public class CacheObject
    {
        public GameObject Prefab;
        public int PoolSize;
        public string Id;
    }
}