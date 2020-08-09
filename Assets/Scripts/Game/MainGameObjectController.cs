using System;
using System.Collections.Generic;
using UnityEngine;

public class MainGameObjectController : MonoBehaviour
{
	private event Action _onUpdate;
	private List<IDisposable> _disposableContainer;
	private IUpdateSystem _updateSystem;

	void Start()
    {
		_disposableContainer = new List<IDisposable>();

		InitGame();
    }

	private void InitGame()
	{
		_updateSystem = new UpdateSystem();
		_onUpdate += _updateSystem.ExternalUpdateCall;

		IGameManager gameManager = new MainGameManager();

		IInputManager inputManager = GetComponent<InputManager>();
		inputManager?.SetGameManager(gameManager);

		var playerControl = new PlayerControlManager(_updateSystem);
		gameManager.SetPlayerControl(playerControl);
		_disposableContainer.Add(playerControl);
	}

	private void Update()
	{
		_onUpdate?.Invoke();
	}

	private void OnDestroy()
	{
		_onUpdate -= _updateSystem.ExternalUpdateCall;
		_updateSystem = null;

		foreach (var disposableObject in _disposableContainer)
		{
			disposableObject.Dispose();
		}
		_disposableContainer.Clear();
		_disposableContainer = null;
	}
}
