using Unity.Mathematics;

public interface IUnitController
{
	bool IsAlive { get; }

	int GetTeamID();
	int GetUnitID();
	float3 GetPosition();

	void SearchClosestEnemy();
	void MakeShoot();
	void GetDamage(int damageRate);
}
