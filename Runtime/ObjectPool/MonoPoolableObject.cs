using UnityEngine;
namespace QuickWeb.ObjectPool{
    public abstract class MonoPoolableObject<T> : MonoBehaviour, IPoolableObject<T>
    where T : IPoolableObject<T> {
        public IObjectPool<T> Pool { get; set; }
        public abstract void OnDespawn(); 
        public abstract void OnSpawn();
    }
}

