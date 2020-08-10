using Unity.Mathematics;

public class PlayerController : UnitController, IPlayerController
{
	private bool _needShoot;

	public PlayerController(UnitSettings settings, IGameManager gameManager, BulletManager bulletManager) : base(settings, gameManager, bulletManager)
	{
		_model = new PlayerModel(gameManager.GetUniqID());
		_model.Health = _settings.HealthPoints;
		_model.Position = _settings.SpawnPoint;
		_model.AddChangeListener(OnModelUpdate);
	}

	public void MoveDown()
	{
		ChangePositionAndDirection(math.back());
	}

	public void MoveLeft()
	{
		ChangePositionAndDirection(math.left());
	}

	public void MoveRight()
	{
		ChangePositionAndDirection(math.right());
	}

	public void MoveUp()
	{
		ChangePositionAndDirection(math.forward());
	}

	private void ChangePositionAndDirection(float3 deltaPosition)
	{
		var prevPos = _model.Position;
		var nextPos = prevPos + deltaPosition * _settings.MoveSpeed / 10f;
		_model.Position = nextPos;
		_model.Direction = math.normalize(nextPos - prevPos);
	}

	public override void MakeShoot()
	{
		if (_needShoot)
			_bulletManager.Shoot(_model.Position, _model.Direction, BulletType.SIMPLE, _model.UnitID);
	}

	public override void SearchClosestEnemy()
	{
		var enemy = _gameManager.GetClosestEnemy(_settings.TeamID, _model.Position);
		if (enemy != null)
		{
			_needShoot = true;
			_model.Direction = math.normalize(enemy.GetPosition() - _model.Position);
		}
		else
		{
			_needShoot = false;
		}
	}
}