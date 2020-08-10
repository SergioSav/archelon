using System.Collections.Generic;
using Unity.Mathematics;

public interface IGameManager
{
	void QuitApplication();

	void SetPlayerControl(IPlayerControlManager playerControl);
	void MovePlayerUp();
	void MovePlayerDown();
	void MovePlayerLeft();
	void MovePlayerRight();

	void SetUnitControllers(List<IUnitController> list);
	IUnitController GetClosestEnemy(int playerTeamID, float3 playerPosition);
}