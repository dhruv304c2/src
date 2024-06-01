public interface IObjectPool<T>  
where T : IPoolableObject<T> {
    bool Initialised {get;}
    public void Initialise(int count, T prefab);
    public T Spawn();
    public void ReturnToPool(T obj);
}
