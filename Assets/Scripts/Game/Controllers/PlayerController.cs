using Assets.Scripts.Game.Model;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : IUnitController
{
	private IUnitModel _model;
	private GameObject _view;
	private UnitSettings _playerSettings;
	private IGameManager _gameManager;

	public PlayerController(UnitSettings playerSettings, IGameManager gameManager)
	{
		_playerSettings = playerSettings;
		_gameManager = gameManager;

		_model = new PlayerModel();
		_model.Position = playerSettings.SpawnPoint;
		_model.AddChangeListener(OnModelUpdate);

		_view = GameObject.Instantiate(playerSettings.ViewPrototype, playerSettings.SpawnPoint, Quaternion.identity);
	}

	private void OnModelUpdate(ModelPropertyName propertyName)
	{
		switch (propertyName)
		{
			case ModelPropertyName.HEALTH:
				UpdateHealthView();
				break;
			case ModelPropertyName.POSITION:
				UpdateViewPosition();
				break;
			case ModelPropertyName.DIRECTION:
				UpdateViewDirection();
				break;
		}
	}

	private void UpdateHealthView()
	{
		// TODO: upd hp ui
	}

	private void UpdateViewPosition()
	{
		_view.transform.position = _model.Position;
	}

	private void UpdateViewDirection()
	{
		_view.transform.forward = _model.Direction;
	}

	public void MakeShoot()
	{
		Debug.LogError("Bang!");
	}

	public void MoveDown()
	{
		_model.Position += math.back();
	}

	public void MoveLeft()
	{
		_model.Position += math.left();
	}

	public void MoveRight()
	{
		_model.Position += math.right();
	}

	public void MoveUp()
	{
		_model.Position += math.forward();
	}

	public void SearchClosestEnemy()
	{
		var enemy = _gameManager.GetClosestEnemy(_playerSettings.TeamID, _model.Position);
		if (enemy != null)
		{
			_model.Direction = math.normalize(enemy.GetPosition() - _model.Position);
		}
	}

	public int GetTeamID()
	{
		return _playerSettings.TeamID;
	}

	public float3 GetPosition()
	{
		return _model.Position;
	}
}
