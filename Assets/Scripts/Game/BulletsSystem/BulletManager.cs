using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

public enum BulletType
{
	SIMPLE,
	BIG_BALL,
	FIREBALL
}

public class BulletManager : IDisposable
{
	private IUpdateSystem _updateSystem;
	private IGameManager _gameManager;
	private BulletSettings[] _bulletSettings;
	private List<IBullet> _activeBullets;
	private List<IBullet> _bulletsForDestroy;
    private Dictionary<BulletType, IBulletPool> _bulletPools;

	public BulletManager(IUpdateSystem updateSystem, IGameManager gameManager, BulletSettings[] bulletSettings)
	{
		_activeBullets = new List<IBullet>();
		_bulletsForDestroy = new List<IBullet>();

		_updateSystem = updateSystem;
		_gameManager = gameManager;
		_bulletSettings = bulletSettings;
        CreatePools();
		_updateSystem.AddSubscriberOnEveryUpdate(OnEveryUpdate);
	}

    private void CreatePools()
    {
        _bulletPools = new Dictionary<BulletType, IBulletPool>();
        foreach (var type in _bulletSettings.Select(b => b.BulletType))
        {
            _bulletPools[type] = BulletPoolFactory.CreateBulletPool(type, _bulletSettings);
        }
    }

    private void OnEveryUpdate()
	{
		foreach (var bullet in _activeBullets)
		{
			bullet.Position += bullet.Direction * bullet.Speed / 10f;
			var hasCollision = _gameManager.CheckCollision(bullet);
			if (hasCollision)
				_bulletsForDestroy.Add(bullet);
		}

		foreach (var bullet in _bulletsForDestroy)
		{
			_activeBullets.Remove(bullet);
			bullet.Deactivate();
            _bulletPools[bullet.BulletType].Push(bullet);
		}
		_bulletsForDestroy.Clear();
	}

	public void Shoot(float3 fromPosition, float3 direction, BulletType bulletType, int unitID)
	{
        var bullet = _bulletPools[bulletType].Pull();
		bullet.SetInitValues(bulletType, fromPosition, direction, unitID);
        bullet.Activate();
		_activeBullets.Add(bullet);
	}

	public void Dispose()
	{
		_updateSystem.RemoveSubscriberOnEveryUpdate(OnEveryUpdate);
		_updateSystem = null;
		_activeBullets.Clear();
		_activeBullets = null;
	}
}