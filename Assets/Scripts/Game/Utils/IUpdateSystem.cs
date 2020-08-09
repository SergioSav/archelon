using System;

public interface IUpdateSystem
{
	void ExternalUpdateCall();
	void AddSubscriberOnEverySecond(Action onEventInvoke);
	void RemoveSubscriberOnEverySecond(Action onEventInvoke);
	void AddSubscriberOnEveryUpdate(Action onEventInvoke);
	void RemoveSubscriberOnEveryUpdate(Action onEventInvoke);
}