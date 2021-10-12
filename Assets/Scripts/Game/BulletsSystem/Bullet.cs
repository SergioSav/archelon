using Unity.Mathematics;
using UnityEngine;

public abstract class Bullet : IBullet
{
    private BulletType _type;
    protected float3 _position;
	protected float3 _direction;
	protected GameObject _view;
	protected BulletSettings _settings;
	protected int _unitID;

	protected Bullet(BulletSettings settings)
	{
		_settings = settings;
		_view = GameObject.Instantiate(settings.ViewPrototype, _position, quaternion.identity);
        Deactivate();
    }

	public float3 Position
	{
		get => _position;
		set
		{
			_position = value;
			UpdateViewPositionAndDirection();
		}
	}
	public float3 Direction
	{
		get => _direction;
		private set { _direction = value; }
	}
	public float Speed => _settings.Speed;
	public float ContactRadius => _settings.ContactRadius;
	public int DamageRate => _settings.DamageRate;
	public int UnitID => _unitID;
    public BulletType BulletType => _type;
	
	public void UpdateViewPositionAndDirection()
	{
		_view.transform.position = _position;
		_view.transform.forward = _direction;
	}

	public void Destroy()
	{
        GameObject.Destroy(_view);
	}

	public void SetInitValues(BulletType type, float3 startPosition, float3 direction, int unitID)
	{
        _type = type;
		_position = startPosition;
		_direction = direction;
		UpdateViewPositionAndDirection();

		_unitID = unitID;
	}

    public void Deactivate()
    {
        _view.SetActive(false);
    }

    public void Activate()
    {
        _view.SetActive(true);
    }
}
