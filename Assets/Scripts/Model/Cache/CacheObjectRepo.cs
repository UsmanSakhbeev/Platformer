using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Platformer
{
    public class CacheObjectRepo : MonoBehaviour
    {
        [FormerlySerializedAs("_cacheObjects")] [SerializeField] private List<CacheObject> _pools;

        private Dictionary<string, Queue<GameObject>> _cache;

        #region Singleton

        public CacheObjectRepo Instance;

        private void Awake() {
            Instance = this;
        }

        private void Start() {
            _cache = new Dictionary<string, Queue<GameObject>>();

            foreach (var pool in _pools) {
                FillCache(pool);
            }
        }

        #endregion


        private void FillCache(CacheObject pool) {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.PoolSize; i++) {
                GameObject obj = Instantiate(pool.Prefab, transform);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            
            _cache.Add(pool.Id,objectPool);
        }

        public GameObject SpawnCacheObject(string tag, Vector3 pos, Quaternion rot) {
            if (!_cache.ContainsKey(tag)) {
                Debug.LogError($"Pool with tag {tag} doesn't exist");
                return null;
            }

            if (_cache[tag].Count > 0) {
                GameObject obj = _cache[tag].Dequeue();
                obj.SetActive(true);
                obj.transform.rotation = rot;
                obj.transform.position = pos;
                _cache[tag].Enqueue(obj);
                return obj;
            }
            else {
                GameObject obj = Instantiate(_pools.FirstOrDefault(x => x.Id == tag).Prefab, pos, rot, transform);
                obj.SetActive(true);
                _cache[tag].Enqueue(obj);
                return obj;
            }
            
        }
    }
}