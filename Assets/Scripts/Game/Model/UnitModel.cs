﻿using System;
using Assets.Scripts.Game.Model;
using Unity.Mathematics;

public abstract class UnitModel : IUnitModel
{
	protected int _health;
	protected float3 _position;
	protected float3 _direction;
	protected Action<ModelPropertyName> _onChange;
	protected int _unitID;

	public UnitModel(int uniqID)
	{
		_unitID = uniqID;
	}

	private event Action<ModelPropertyName> _propertyChanged;

	public float3 Position
	{
		get => _position;
		set
		{
			_position = value;
			OnPropertyChanged(ModelPropertyName.POSITION);
		}
	}

	public float3 Direction
	{
		get => _direction;
		set
		{
			_direction = value;
			OnPropertyChanged(ModelPropertyName.DIRECTION);
		}
	}

	public int Health
	{
		get => _health;
		set
		{
			_health = value;
			OnPropertyChanged(ModelPropertyName.HEALTH);
		}
	}

	public int UnitID => _unitID;

	private void OnPropertyChanged(ModelPropertyName propertyName)
	{
		_propertyChanged?.Invoke(propertyName);
	}

	public void AddChangeListener(Action<ModelPropertyName> OnChange)
	{
		if (_onChange != null) return;

		_onChange = OnChange;

		_propertyChanged += _onChange;
	}

	public void RemoveChangeListener()
	{
		if (_onChange == null) return;

		_propertyChanged -= _onChange;
	}
}
