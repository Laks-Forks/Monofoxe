﻿using System;

namespace Monofoxe.Engine.ECS
{
	/// <summary>
	/// Stores data, which will be processed by corresponding systems.
	/// </summary>
	public abstract class Component : ICloneable
	{
		/// <summary>
		/// Owner of a component.
		/// 
		/// NOTE: Component should ALWAYS have an owner. 
		/// </summary>
		public Entity Owner {get; internal set;}

		/// <summary>
		/// Tells if this component was initialized.
		/// </summary>
		public bool Initialized = false;

		/// <summary>
		/// If component is enabled, it will be processed by Create and Update methods.
		/// </summary>
		public bool Enabled 
		{
			get => _enabled; 
			set
			{
				if (_enabled != value)
				{
					_enabled = value;
					if (value)
					{
						Owner.Layer.AddComponent(this);
					}
					else
					{
						Owner.Layer.RemoveComponent(this);
					}
				}
			}
		}
		private bool _enabled = true;
		
		/// <summary>
		/// If component is visible, it will be processed by Draw method.
		/// </summary>
		public bool Visible = true;
		

		/// <summary>
		/// Creates a new object that is a copy of the current instance.
		/// 
		/// NOTE: If you are going to use json entity templates, 
		/// this method has to be properly implemented! 
		/// </summary>
		public abstract object Clone();
	}
}
