using Assets.Scripts.Game.Model;
using UnityEngine;

public class PlayerController : IUnitController
{
	private IUnitModel _model;
	private GameObject _view;
	private UnitSettings _playerSettings;

	public PlayerController(UnitSettings playerSettings)
	{
		_playerSettings = playerSettings;

		_model = new PlayerModel();
		_view = GameObject.Instantiate(playerSettings.view, playerSettings.spawnPoint, Quaternion.identity);
		_model.AddChangeListener(OnModelUpdate);
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
		_model.Position += Vector3.back;
	}

	public void MoveLeft()
	{
		_model.Position += Vector3.left;
	}

	public void MoveRight()
	{
		_model.Position += Vector3.right;
	}

	public void MoveUp()
	{
		_model.Position += Vector3.forward;
	}

	public void SearchClosestEnemy()
	{
		// TODO:
		Debug.LogError("search...");
	}
}
