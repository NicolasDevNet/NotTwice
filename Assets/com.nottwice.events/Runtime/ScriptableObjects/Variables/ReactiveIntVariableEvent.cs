using Assets.com.nottwice.serializables.Runtime.Operators;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables
{
	[CreateAssetMenu(fileName = "ReactiveIntVariableEvent", menuName = "NotTwice/Events/Variables/ReactiveIntVariableEvent")]
	public class ReactiveIntVariableEvent : ReactiveVariableEvent
	{
		public IntReactiveProperty Value;

		public List<SerializableIntCondition> Conditions;

		public override void Subscribe()
		{
			if (BoundEvent != null)
			{
				if (Conditions.Count > 0)
				{
					Value.Where(_ => Conditions.All(cdn => cdn.IsTrue(Value.Value)));
				}

				_valueObserver = Value.Subscribe(_ => 
				{
					BoundEvent.Raise();
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

		public void SetValue(int value)
		{
			Value.Value = value;
		}

		public void SetValueAndForceNotify(int value)
		{
			Value.SetValueAndForceNotify(value);
		}
	}
}
