using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameSettings", order = 2)]
public class GameSettings : ScriptableObject
{
	public int EnemyTeamID;
	public bool IsBallisticShoot;		// TODO:
	public bool NeedShakeScreenOnHit;   
	public bool IsDropCoinMode;         // TODO:

	public float FieldSize = 96;
	public float HalfFieldSize => FieldSize * 0.5f;
}
