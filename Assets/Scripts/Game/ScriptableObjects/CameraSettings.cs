using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraSetings", menuName = "ScriptableObjects/CameraSetings", order = 4)]
public class CameraSettings : ScriptableObject
{
	public float3 InitPosition;
	public float3 OffsetPosition;
}
