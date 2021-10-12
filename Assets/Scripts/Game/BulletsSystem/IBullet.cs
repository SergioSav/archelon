using Unity.Mathematics;

public interface IBullet
{
	float3 Position { get; set; }
	float3 Direction { get; }
	float Speed { get; }
	float ContactRadius { get; }
	int DamageRate { get; }
	int UnitID { get; }
    BulletType BulletType { get; }

    void Activate();
    void Deactivate();
    void Destroy();
	void SetInitValues(BulletType bulletType, float3 startPosition, float3 direction, int unitID);
}
