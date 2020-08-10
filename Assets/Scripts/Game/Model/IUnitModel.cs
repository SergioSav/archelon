using System;
using UnityEngine;

namespace Assets.Scripts.Game.Model
{
	public interface IUnitModel
	{
		int Health { get; set; }
		Vector3 Position { get; set; }
		Vector3 Direction { get; set; }

		void AddChangeListener(Action<ModelPropertyName> OnChange);
		void RemoveChangeListener();
	}

	public enum ModelPropertyName
	{
		HEALTH,
		POSITION,
		DIRECTION
	}
}
