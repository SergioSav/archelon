using System;
using Unity.Mathematics;

namespace Assets.Scripts.Game.Model
{
	public interface IUnitModel
	{
		int Health { get; set; }
		float3 Position { get; set; }
		float3 Direction { get; set; }
		int UnitID { get; }

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
