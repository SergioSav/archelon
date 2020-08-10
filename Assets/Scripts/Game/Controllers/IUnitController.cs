using Unity.Mathematics;

public interface IUnitController
{
	int GetTeamID();
	float3 GetPosition();

	void SearchClosestEnemy();
	void MakeShoot();
}
