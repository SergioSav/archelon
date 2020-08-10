using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitSettings", order = 1)]
public class UnitSettings : ScriptableObject
{
	public Vector3 SpawnPoint;
	public GameObject ViewPrototype;
	public int TeamID;
}
