﻿using NaughtyAttributes;
using UnityEngine;

namespace NotTwice.Patterns.DependancyRegistration.Runtime.Abstract
{
	public abstract class NTBaseContainerScriptableObject : ScriptableObject
	{
		[Required]
		public NTDependancyContainer Container;

		protected T GetService<T>()
			where T : class
		{
			return Container.GetService<T>();
		}
	}
}
