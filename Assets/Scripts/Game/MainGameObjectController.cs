using System;
using System.Collections.Generic;
using UnityEngine;

public class MainGameObjectController : MonoBehaviour
{
	private event Action _onUpdate;
	private List<IDisposable> _disposableContainer;
	private IUpdateSystem _updateSystem;
	private PlayerController _playerController;

	[SerializeField] private GameSettings _gameSettings;
	[SerializeField] private UnitSettings _playerSettings;
	[SerializeField] private UnitSettings[] _enemySettings;

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

		GenerateUnitControllers(gameManager);

		IInputManager inputManager = GetComponent<InputManager>();
		inputManager?.SetGameManager(gameManager);

		var playerControl = new PlayerControlManager(_updateSystem);
		playerControl.SetPlayerController(_playerController);
		gameManager.SetPlayerControl(playerControl);
		_disposableContainer.Add(playerControl);

		var enemyControl = new EnemyControlManager(_updateSystem, gameManager, _gameSettings);
		_disposableContainer.Add(enemyControl);
	}

	private void GenerateUnitControllers(IGameManager gameManager)
	{
		_playerController = new PlayerController(_playerSettings, gameManager);

		var unitControllersList = new List<IUnitController> { _playerController };

		foreach (var enemySet in _enemySettings)
		{
			var enemy = new EnemyController(enemySet, gameManager);
			unitControllersList.Add(enemy);
		}

		gameManager.SetUnitControllers(unitControllersList);
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
