using System;
using NotTwice.Events.Runtime.ScriptableObjects.Events;
using NotTwice.Scene.Runtime.Abstract;
using UnityEngine;

namespace Assets.Samples.Scene.Scripts
{
	[CreateAssetMenu(fileName = "OnProgressSample", menuName = "NotTwice/Samples/Scene/OnProgressSample")]
	public class OnProgressSample : NTBaseSceneProgressHandler
	{
		public NTFloatGameEvent GameEvent;

		public override void OnProgress(float progress)
		{
			GameEvent?.Raise(progress);
		}
	}
}
