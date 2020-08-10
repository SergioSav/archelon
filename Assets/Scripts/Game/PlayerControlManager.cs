using System;

enum PlayerState
{
	IDLE,
	MOVING
}

public class PlayerControlManager : IPlayerControlManager, IDisposable
{
	private static int FRAME_BEFORE_SHOOT = 30;

	private IUpdateSystem _updateSystem;
	private PlayerState _currentState;
	private int _idleTimer;
	private IPlayerController _playerController;

	public PlayerControlManager(IUpdateSystem updateSystem)
	{
		_currentState = PlayerState.IDLE;
		_updateSystem = updateSystem;
		updateSystem.AddSubscriberOnEveryUpdate(OnSystemUpdate);
	}

	private void OnSystemUpdate()
	{
		if (FRAME_BEFORE_SHOOT > 0)
		{
			if (_currentState == PlayerState.IDLE)
			{
				RotateToClosestEnemy();
				_idleTimer++;
			}
			if (_idleTimer >= FRAME_BEFORE_SHOOT)
			{
				_idleTimer = 0;
				MakeShoot();
			}
		}
		else
		{
			if (_currentState == PlayerState.IDLE)
			{
				RotateToClosestEnemy();
				MakeShoot();
			}
		}
		_currentState = PlayerState.IDLE;
	}

	public void RotateToClosestEnemy()
	{
		_playerController.SearchClosestEnemy();
	}

	public void MakeShoot()
	{
		_playerController.MakeShoot();
	}

	public void MoveDown()
	{
		_currentState = PlayerState.MOVING;
		_playerController.MoveDown();
	}

	public void MoveLeft()
	{
		_currentState = PlayerState.MOVING;
		_playerController.MoveLeft();
	}

	public void MoveRight()
	{
		_currentState = PlayerState.MOVING;
		_playerController.MoveRight();
	}

	public void MoveUp()
	{
		_currentState = PlayerState.MOVING;
		_playerController.MoveUp();
	}

	public void Dispose()
	{
		_updateSystem.RemoveSubscriberOnEveryUpdate(OnSystemUpdate);
		_updateSystem = null;
	}

	public void SetPlayerController(IPlayerController playerController)
	{
		_playerController = playerController;
	}
}
