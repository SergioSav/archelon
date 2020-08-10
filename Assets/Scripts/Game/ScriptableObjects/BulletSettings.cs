using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/BulletSettings", order = 2)]
public class BulletSettings : ScriptableObject
{
	public GameObject ViewPrototype;
	[Range(1f, 10f)]
	public float Speed = 5f;
	[Range(1f, 5f)]
	public float ContactRadius = 1f;
	public BulletType BulletType;
	[Range(1, 3)]
	public int DamageRate = 1;
}
