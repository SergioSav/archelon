using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameSettings", order = 2)]
public class GameSettings : ScriptableObject
{
	public int EnemyTeamID;
	public bool IsBallisticShoot;		// TODO:
	public bool NeedShakeScreenOnHit;   // TODO:
	public bool IsDropCoinMode;			// TODO:
}
