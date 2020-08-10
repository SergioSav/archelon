using Unity.Mathematics;

public interface IUnitController
{
	void SearchClosestEnemy();
	void MakeShoot();
	void MoveDown();
	void MoveLeft();
	void MoveRight();
	void MoveUp();

	int GetTeamID();
	float3 GetPosition();
}