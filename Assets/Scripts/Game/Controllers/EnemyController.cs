using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class EnemyController : UnitController, IEnemyController
{
	private float3 _nextRoutePoint;
	private int _curIndex;

	public EnemyController(UnitSettings settings, GameSettings gameSettings, IGameManager gameManager, BulletManager bulletManager) : base(settings, gameSettings, gameManager, bulletManager)
	{
		_model = new EnemyModel(gameManager.GetUniqID());
		_model.Health = _settings.HealthPoints;
		_model.Position = _settings.SpawnPoint;
		_nextRoutePoint = _settings.SpawnPoint;
		_model.AddChangeListener(OnModelUpdate);
	}
	
	private void MoveTo(float3 nextRoutePoint)
	{
		_model.Position = math.lerp(_model.Position, nextRoutePoint, 1/math.distance(_model.Position, nextRoutePoint) * _settings.MoveSpeed / 10f);
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
		var availableRoutePoints = _settings.PatrolRouteContainer.GetComponentsInChildren<Transform>()
			.Skip(1)
			.OrderBy(t => t.name)
			.Select(t => t.position)
			.ToList();
		var nextIndex = (_curIndex + 1) % availableRoutePoints.Count;
		_curIndex = nextIndex;
		return availableRoutePoints[_curIndex];
	}
}