using System;
using System.Collections.Generic;
using UnityEngine;

public class MainGameObjectController : MonoBehaviour
{
	private event Action _onUpdate;
	private List<IDisposable> _disposableContainer;
	private IUpdateSystem _updateSystem;
	private PlayerController _playerController;

	[SerializeField] private UnitSettings PlayerSettings;
	[SerializeField] private UnitSettings EnemySettings;

	void Start()
    {
		_disposableContainer = new List<IDisposable>();

		InitGame();
    }

	private void InitGame()
	{
		_updateSystem = new UpdateSystem();
		_onUpdate += _updateSystem.ExternalUpdateCall;

		IGameManager gameManager = new GameManager();

		GenerateUnitControllers();

		IInputManager inputManager = GetComponent<InputManager>();
		inputManager?.SetGameManager(gameManager);

		var playerControl = new PlayerControlManager(_updateSystem);
		playerControl.SetPlayerController(_playerController);
		gameManager.SetPlayerControl(playerControl);
		_disposableContainer.Add(playerControl);
	}

	private void GenerateUnitControllers()
	{
		_playerController = new PlayerController(PlayerSettings);
		var en1 = new EnemyController(EnemySettings);
		var en2 = new EnemyController(EnemySettings);
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
