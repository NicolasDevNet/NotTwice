using Assets.com.nottwice.serializables.Runtime.Operators;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables
{
	[CreateAssetMenu(fileName = "ReactiveFloatVariableEvent", menuName = "NotTwice/Events/Variables/ReactiveFloatVariableEvent")]
	public class ReactiveFloatVariableEvent : ReactiveVariableEvent<FloatReactiveProperty, float>
	{
		public List<SerializableFloatCondition> Conditions;

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

		public void SetValue(float value)
		{
			Value.Value = value;
		}

		public void SetValueAndForceNotify(float value)
		{
			Value.SetValueAndForceNotify(value);
		}
	}
}
