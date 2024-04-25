using Assets.com.nottwice.serializables.Runtime.Operators;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables
{
	[CreateAssetMenu(fileName = "ReactiveVector2VariableEvent", menuName = "NotTwice/Events/Variables/ReactiveVector2VariableEvent")]
	public class ReactiveVector2VariableEvent : ReactiveVariableEvent<Vector2ReactiveProperty, Vector2>
	{
		public List<SerializableVector2Condition> Conditions;

		public override void Subscribe()
		{
			if (BoundEvent != null)
			{
				if (Conditions.Count > 0)
				{
					Value.Where(_ => Conditions.All(cdn => cdn.IsTrue(Value.Value)));
				}

				_valueObserver = Value.Subscribe(value => 
				{
					BoundEvent.Raise(value);
				});
			}
		}

		public override void UnSubscribe()
		{
			if (BoundEvent != null)
			{
				_valueObserver.Dispose();
			}
		}

		public void SetValue(Vector2 value)
		{
			Value.Value = value;
		}

		public void SetValueAndForceNotify(Vector2 value)
		{
			Value.SetValueAndForceNotify(value);
		}
	}
}
