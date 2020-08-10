using Assets.Scripts.Game.Model;
using Unity.Mathematics;
using UnityEngine;

public abstract class UnitController : IUnitController
{
	protected IUnitModel _model;
	protected GameObject _view;
	protected UnitSettings _settings;
	protected IGameManager _gameManager;
	protected BulletManager _bulletManager;

	public bool IsAlive => _model.Health > 0;

	public UnitController(UnitSettings settings, IGameManager gameManager, BulletManager bulletManager)
	{
		_settings = settings;
		_gameManager = gameManager;
		_bulletManager = bulletManager;
		_view = GameObject.Instantiate(_settings.ViewPrototype, _settings.SpawnPoint, Quaternion.identity);
	}

	protected void OnModelUpdate(ModelPropertyName propertyName)
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

	protected void UpdateHealthView()
	{
		// TODO: upd hp ui
		if (!IsAlive)
		{
			GameObject.Destroy(_view);
			_model.RemoveChangeListener();
		}
	}

	protected void UpdateViewPosition()
	{
		_view.transform.position = _model.Position;
	}

	protected void UpdateViewDirection()
	{
		_view.transform.forward = _model.Direction;
	}

	virtual public void SearchClosestEnemy()
	{
		var player = _gameManager.GetClosestEnemy(_settings.TeamID, _model.Position);
		if (player != null)
		{
			_model.Direction = math.normalize(player.GetPosition() - _model.Position);
		}
	}

	public int GetTeamID()
	{
		return _settings.TeamID;
	}

	public float3 GetPosition()
	{
		return _model.Position;
	}

	virtual public void MakeShoot()
	{
	}

	public void GetDamage(int damageRate)
	{
		_model.Health -= damageRate;
	}

	public int GetUnitID()
	{
		return _model.UnitID;
	}
}

