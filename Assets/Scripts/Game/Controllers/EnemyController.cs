using Assets.Scripts.Game.Model;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : IEnemyController
{
	private IUnitModel _model;
	private GameObject _view;
	private UnitSettings _enemySettings;
	private IGameManager _gameManager;

	private float3 _nextRoutePoint;
	private int _curIndex;

	public EnemyController(UnitSettings enemySettings, IGameManager gameManager)
	{
		_enemySettings = enemySettings;
		_gameManager = gameManager;

		_model = new EnemyModel();
		_model.Position = _enemySettings.SpawnPoint;
		_nextRoutePoint = _enemySettings.SpawnPoint;
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

	public void SearchClosestEnemy()
	{
		var player = _gameManager.GetClosestEnemy(_enemySettings.TeamID, _model.Position);
		if (player != null)
		{
			_model.Direction = math.normalize(player.GetPosition() - _model.Position);
		}
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
		Debug.Log("pew!");
	}

	private void MoveTo(float3 nextRoutePoint)
	{
		_model.Position = math.lerp(_model.Position, nextRoutePoint, 1/math.distance(_model.Position, nextRoutePoint) * _enemySettings.MoveSpeed / 10f);
	}

	public void MoveOnRoute()
	{
		if (math.distance(_model.Position, _nextRoutePoint) <= 0.5f)
		{
			_nextRoutePoint = GetNextRoutePoint();
		}
		else
		{
			MoveTo(_nextRoutePoint);
		}
	}

	private float3 GetNextRoutePoint()
	{
		var availableRoutePoints = _enemySettings.PatrolRouteContainer.GetComponentsInChildren<Transform>()
			.Skip(1)
			.OrderBy(t => t.name)
			.Select(t => t.position)
			.ToList();
		var nextIndex = (_curIndex + 1) % availableRoutePoints.Count;
		_curIndex = nextIndex;
		return availableRoutePoints[_curIndex];
	}
}
