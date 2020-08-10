using System.Collections.Generic;
using Unity.Mathematics;

public interface IGameManager
{
	void QuitApplication();

	int GetUniqID();

	void SetPlayerControl(IPlayerControlManager playerControl);
	void MovePlayerUp();
	void MovePlayerDown();
	void MovePlayerLeft();
	void MovePlayerRight();

	void SetCameraManager(ICameraManager cameraManager);

	void SetUnitControllers(List<IUnitController> list);
	IUnitController GetClosestEnemy(int playerTeamID, float3 playerPosition);
	List<IEnemyController> GetEnemies(int enemiesTeamID);
	bool CheckCollision(IBullet bullet);
}