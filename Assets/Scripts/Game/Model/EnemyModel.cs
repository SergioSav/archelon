using System;
using Assets.Scripts.Game.Model;
using UnityEngine;

public class EnemyModel : IUnitModel
{
	public int Health { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public Vector3 Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
	public Vector3 Direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public void AddChangeListener(Action<ModelPropertyName> OnChange)
	{
		throw new NotImplementedException();
	}

	public void RemoveChangeListener()
	{
		throw new NotImplementedException();
	}
}
