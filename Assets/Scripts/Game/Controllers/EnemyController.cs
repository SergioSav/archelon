using Assets.Scripts.Game.Model;
using UnityEngine;

public class EnemyController
{
	private IUnitModel _model;
	private GameObject _view;
	private UnitSettings _enemySettings;

	public EnemyController(UnitSettings enemySettings)
	{
		_enemySettings = enemySettings;

		_model = new PlayerModel();
		_view = GameObject.Instantiate(enemySettings.view, enemySettings.spawnPoint, Quaternion.identity);
	}

}
