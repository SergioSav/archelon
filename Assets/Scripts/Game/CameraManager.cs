using UnityEngine;

public class CameraManager : MonoBehaviour, ICameraManager
{
	[SerializeField] private Camera _camera;
	[SerializeField] private CameraSettings _cameraSettings;
	[SerializeField] private Animator _cameraAnimator;
	private IUnitController _target;

	public void SetFollowTarget(IUnitController target)
	{
		_target = target;
	}

	public void Shake()
	{
		_cameraAnimator.SetTrigger("needShake");
	}

	void Start()
    {
		_camera.transform.position = _cameraSettings.InitPosition;
    }

    void Update()
    {
		_camera.transform.position = Vector3.Lerp(_camera.transform.position, 
			new Vector3(_target.GetPosition().x, _camera.transform.position.y, _target.GetPosition().z) + 
			(Vector3)_cameraSettings.OffsetPosition, 0.1f);
    }
}
