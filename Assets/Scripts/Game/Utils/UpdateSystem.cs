using System;

public class UpdateSystem : IUpdateSystem
{
	private long _lastTimeForSecond;

	private event Action _onEverySeconds;
	private event Action _onEveryUpdate;

	public void ExternalUpdateCall()
	{
		var currentTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
		var deltaTime = currentTime - _lastTimeForSecond;

		if (deltaTime >= 1000)
		{
			_onEverySeconds?.Invoke();
			_lastTimeForSecond = currentTime;
		}

		_onEveryUpdate?.Invoke();
	}

	public void AddSubscriberOnEverySecond(Action onEventInvoke)
	{
		_onEverySeconds += onEventInvoke;
	}

	public void RemoveSubscriberOnEverySecond(Action onEventInvoke)
	{
		_onEverySeconds -= onEventInvoke;
	}

	public void AddSubscriberOnEveryUpdate(Action onEventInvoke)
	{
		_onEveryUpdate += onEventInvoke;
	}

	public void RemoveSubscriberOnEveryUpdate(Action onEventInvoke)
	{
		_onEveryUpdate -= onEventInvoke;
	}
}
