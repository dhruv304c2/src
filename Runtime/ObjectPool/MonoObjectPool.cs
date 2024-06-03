using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QuickWeb.ObjectPool {
    public class MonoObjectPool<T> : MonoBehaviour, IObjectPool<T> 
    where T : MonoBehaviour, IPoolableObject<T> {
        private List<T> _pool = new(); 
        private T _prefab;
        private Transform _poolTransform;    
        public bool Initialised { get; private set; } = false;

        public void ReturnToPool(T obj) {
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_poolTransform);;
            obj.OnDespawn();
            _pool.Add(obj);
        }

        public void Initialise(int count, T prefab) {
            _poolTransform = new GameObject(typeof(T).Name + "Pool").transform;
            _prefab = prefab;
            for (int i = 0; i < count; i++) {
                InstantiateObjectToPool(_prefab); 
            }
            Initialised = true;
        }

        public T Spawn() {
            if (!_pool.Any()) {
                InstantiateObjectToPool(_prefab);
            }
            var spawned = _pool.First();
            spawned.transform.SetParent(null);
            spawned.gameObject.SetActive(true);
            spawned.OnSpawn();
            _pool.Remove(spawned);
            return spawned;
        }

    private void InstantiateObjectToPool(T prefab) {
            T obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(_poolTransform);
            obj.Pool = this;
            _pool.Add(obj);
        } 
    }
}