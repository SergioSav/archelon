using System;
using System.Linq;

public class BulletFactory
{
	public static IBullet CreateBullet(BulletType bulletType, BulletSettings[] bulletSettings)
	{
		var settings = bulletSettings.FirstOrDefault(s => s.BulletType == bulletType);
		switch (bulletType)
		{
			case BulletType.SIMPLE:
				return new SimpleBullet(settings);
			case BulletType.BIG_BALL:
				return new BigBallBullet(settings);
			case BulletType.FIREBALL:
				return new FireballBullet(settings);
		}
		throw new NotSupportedException($"Bullet type '{bulletType}' not supported");
	}
}
