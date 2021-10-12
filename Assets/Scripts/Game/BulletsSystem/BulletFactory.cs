using System;
using System.Linq;

public class BulletPoolFactory
{
	public static IBulletPool CreateBulletPool(BulletType bulletType, BulletSettings[] bulletSettings)
	{
		var settings = bulletSettings.FirstOrDefault(s => s.BulletType == bulletType);
		switch (bulletType)
		{
			case BulletType.SIMPLE:
				return new BulletPool<SimpleBullet>(settings, true);
			case BulletType.BIG_BALL:
				return new BulletPool<BigBallBullet>(settings, true);
			case BulletType.FIREBALL:
				return new BulletPool<FireballBullet>(settings, true);
		}
		throw new NotSupportedException($"Bullet type '{bulletType}' not supported");
	}
}
