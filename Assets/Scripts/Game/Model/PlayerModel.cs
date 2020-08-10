﻿using Assets.Scripts.Game.Model;
using System;
using UnityEngine;

public class PlayerModel : IUnitModel
{
	private int health;
	private Vector3 position;
	private Vector3 direction;
	private Action<ModelPropertyName> _onChange;

	private event Action<ModelPropertyName> _propertyChanged;

	public Vector3 Position
	{
		get => position;
		set
		{
			position = value;
			OnPropertyChanged(ModelPropertyName.POSITION);
		}
	}

	public Vector3 Direction
	{
		get => direction;
		set
		{
			direction = value;
			OnPropertyChanged(ModelPropertyName.DIRECTION);
		}
	}

	public int Health {
		get => health;
		set
		{
			health = value;
			OnPropertyChanged(ModelPropertyName.HEALTH);
		}
	}

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
