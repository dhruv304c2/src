public interface IPoolableObject<T> where T : IPoolableObject<T>{
    IObjectPool<T> Pool { get; set; }
    void OnSpawn();
    void OnDespawn();
    void DeSpawn() => Pool.ReturnToPool((T)this);
}
