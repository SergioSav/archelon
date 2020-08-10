using Assets.Scripts.Game.Model;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : IUnitController
{
	private IUnitModel _model;
	private GameObject _view;
	private UnitSettings _enemySettings;
	private IGameManager _gameManager;

	public EnemyController(UnitSettings enemySettings, IGameManager gameManager)
	{
		_enemySettings = enemySettings;
		_gameManager = gameManager;

		_model = new EnemyModel();
		_model.Position = _enemySettings.SpawnPoint;
		_model.AddChangeListener(OnModelUpdate);

		_view = GameObject.Instantiate(_enemySettings.ViewPrototype, _enemySettings.SpawnPoint, Quaternion.identity);
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
		_gameManager.GetClosestEnemy(_enemySettings.TeamID, _model.Position);
	}

	public int GetTeamID()
	{
		return _enemySettings.TeamID;
	}

	public float3 GetPosition()
	{
		return _model.Position;
	}

	public void MakeShoot()
	{
		throw new System.NotImplementedException();
	}
}
