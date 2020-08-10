using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

public class GameManager : IGameManager
{
	private IPlayerControlManager _playerControlManager;
	private List<IUnitController> _unitControllersList;

	public GameManager()
	{
	}

	public void QuitApplication()
	{
		UnityEngine.Application.Quit();
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#endif
	}
	
	#region PlayerControl
	public void SetPlayerControl(IPlayerControlManager playerControl)
	{
		_playerControlManager = playerControl;
	}

	public void MovePlayerUp()
	{
		_playerControlManager.MoveUp();
	}

	public void MovePlayerDown()
	{
		_playerControlManager.MoveDown();
	}

	public void MovePlayerLeft()
	{
		_playerControlManager.MoveLeft();
	}

	public void MovePlayerRight()
	{
		_playerControlManager.MoveRight();
	}
	#endregion

	public void SetUnitControllers(List<IUnitController> unitControllersList)
	{
		_unitControllersList = unitControllersList;
	}

	public IUnitController GetClosestEnemy(int playerTeamID, float3 playerPosition)
	{
		IUnitController closestEnemy = null;
		var minDistance = float.MaxValue;
		foreach (var controller in _unitControllersList)
		{
			if (controller.GetTeamID() != playerTeamID)
			{
				var dist = math.distance(controller.GetPosition(), playerPosition);
				if (dist < minDistance)
				{
					minDistance = dist;
					closestEnemy = controller;
				}
			}
		}
		return closestEnemy;
	}

	public List<IEnemyController> GetEnemies(int enemiesTeamID)
	{
		return _unitControllersList
			.Where(c => c.GetTeamID() == enemiesTeamID)
			.Select(c => c as IEnemyController)
			.ToList();
	}
}
