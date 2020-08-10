using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/UnitSettings", order = 1)]
public class UnitSettings : ScriptableObject
{
	public string viewName;
	public Vector3 spawnPoint;
	public GameObject view;
}
