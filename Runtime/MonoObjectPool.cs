using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonoObjectPool<T> :MonoBehaviour, IObjectPool<T> 
where T : MonoBehaviour, IPoolableObject<T> {
    private List<T> _pool = new List<T>();
    private T _prefab;
    public bool Initialised { get; private set; } = false;    

    public void ReturnToPool(T obj) {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        obj.OnDespawn();
        _pool.Add(obj);
    }

    public void Initialise(int count, T prefab) {
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
        obj.transform.SetParent(transform);
        obj.Pool = this;
        _pool.Add(obj);
    } 
}
