using System;
using System.Collections.Generic;

public class EnemyControlManager : IDisposable
{
	private IUpdateSystem _updateSystem;
	private int _idleTimer;
	private List<IEnemyController> _enemyList;

	public EnemyControlManager(IUpdateSystem updateSystem, IGameManager gameManager, GameSettings gameSettings)
	{
		_updateSystem = updateSystem;
		updateSystem.AddSubscriberOnEverySecond(OnEverySecond);
		updateSystem.AddSubscriberOnEveryUpdate(OnEveryUpdate);

		_enemyList = gameManager.GetEnemies(gameSettings.EnemyTeamID);
	}

	private void OnEveryUpdate()
	{
		AllMoveOnRoute();
	}

	private void OnEverySecond()
	{
		RotateToClosestEnemy();
		MakeShoot();
	}

	private void RotateToClosestEnemy()
	{
		foreach (var controller in _enemyList)
		{
			controller.SearchClosestEnemy();
		}
	}

	private void MakeShoot()
	{
		foreach (var controller in _enemyList)
		{
			controller.MakeShoot();
		}
	}

	private void AllMoveOnRoute()
	{
		foreach (var controller in _enemyList)
		{
			controller.MoveOnRoute();
		}
	}

	public void Dispose()
	{
		_updateSystem.RemoveSubscriberOnEverySecond(OnEverySecond);
		_updateSystem.RemoveSubscriberOnEveryUpdate(OnEveryUpdate);
		_updateSystem = null;
	}
}
