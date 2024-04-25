using Assets.com.nottwice.serializables.Runtime.Operators;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables
{
	[CreateAssetMenu(fileName = "ReactiveStringVariableEvent", menuName = "NotTwice/Events/Variables/ReactiveStringVariableEvent")]
	public class ReactiveStringVariableEvent : ReactiveVariableEvent<StringReactiveProperty, string>
	{
		public List<SerializableStringCondition> Conditions;

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

		public void SetValue(string value)
		{
			Value.Value = value;
		}

		public void SetValueAndForceNotify(string value)
		{
			Value.SetValueAndForceNotify(value);
		}
	}
}
