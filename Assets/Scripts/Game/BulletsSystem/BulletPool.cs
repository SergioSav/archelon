using System;
using System.Collections.Generic;

public interface IBulletPool
{
    IBullet Pull();
    void Push(IBullet bullet);
}

public class BulletPool<T> : IBulletPool where T : IBullet
{
    private const int PREWARM_COUNT = 10;

    private readonly BulletSettings _bulletSettings;
    private List<IBullet> _bulletPool;

    public BulletPool(BulletSettings bulletSettings, bool needPrewarm)
    {
        _bulletSettings = bulletSettings;
        _bulletPool = new List<IBullet>();
        if (needPrewarm)
        {
            for (int i = 0; i < PREWARM_COUNT; i++)
            {
                _bulletPool.Add(GenerateBullet());
            }
        }
    }

    public IBullet Pull()
    {
        if (_bulletPool.Count > 0)
        {
            var bullet = _bulletPool[_bulletPool.Count - 1];
            _bulletPool.Remove(bullet);
            return bullet;
        }
        else
        {
            return GenerateBullet();
        }
    }

    public void Push(IBullet bullet)
    {
        bullet.Deactivate();
        _bulletPool.Add(bullet);
    }

    private T GenerateBullet()
    {
        return (T)Activator.CreateInstance(typeof(T), new object[] { _bulletSettings });
    }
}
