using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.serializables.Runtime.Operators;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables
{
	[CreateAssetMenu(fileName = "ReactiveVector3VariableEvent", menuName = "NotTwice/Events/Variables/ReactiveVector3VariableEvent")]
	public class ReactiveVector3VariableEvent : ReactiveVariableEvent
	{
		public Vector3ReactiveProperty Value;

		public List<SerializableVector3Condition> Conditions;

		private ILogger _logger;

		public void OnEnable()
		{
			_logger = AppContainer.Get<ILogger>();
		}

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
					_logger.Log(LogType.Log, $"Event raise: {BoundEvent.name}");
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

		public void SetValue(Vector3 value)
		{
			Value.Value = value;
		}

		public void SetValueAndForceNotify(Vector3 value)
		{
			Value.SetValueAndForceNotify(value);
		}
	}
}
