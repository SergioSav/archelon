using System;

enum PlayerState
{
	IDLE,
	MOVING
}

public class PlayerControlManager : IPlayerControlManager, IDisposable
{
	private static int TIME_BEFORE_SHOOT = 2;

	private IUpdateSystem _updateSystem;
	private PlayerState _currentState;
	private int _idleTimer;

	public PlayerControlManager(IUpdateSystem updateSystem)
	{
		_currentState = PlayerState.IDLE;
		_updateSystem = updateSystem;
		updateSystem.AddSubscriberOnEverySecond(OnEverySecond);
	}

	private void OnEverySecond()
	{
		if (_currentState == PlayerState.IDLE)
			_idleTimer++;
		if (_idleTimer >= TIME_BEFORE_SHOOT)
		{
			_idleTimer = 0;
			MakeShoot();
		}
	}

	public void MakeShoot()
	{
		// TODO: 
	}

	public void MoveDown()
	{
		_currentState = PlayerState.MOVING;
	}

	public void MoveLeft()
	{
		_currentState = PlayerState.MOVING;
	}

	public void MoveRight()
	{
		_currentState = PlayerState.MOVING;
	}

	public void MoveUp()
	{
		_currentState = PlayerState.MOVING;
	}

	public void Dispose()
	{
		_updateSystem.RemoveSubscriberOnEverySecond(OnEverySecond);
		_updateSystem = null;
	}
}
