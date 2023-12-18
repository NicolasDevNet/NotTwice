using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.serializables.Runtime.Operators;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables
{
	[CreateAssetMenu(fileName = "ReactiveBoolVariableEvent", menuName = "NotTwice/Events/Variables/ReactiveBoolVariableEvent")]
	public class ReactiveBoolVariableEvent : ReactiveVariableEvent
	{
		public BoolReactiveProperty Value;

		public SerializableBoolCondition Condition;

		public override void Subscribe()
		{
			if (BoundEvent != null)
			{
				if (Condition != null)
				{
					Value.Where(_ => Condition.IsTrue(Value.Value));
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

		public void SetValue(bool value)
		{
			Value.Value = value;
		}

		public void SetValueAndForceNotify(bool value)
		{
			Value.SetValueAndForceNotify(value);
		}
	}
}
