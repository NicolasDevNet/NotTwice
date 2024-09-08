using NaughtyAttributes;
using NotTwice.Patterns.State.Runtime.Abstract;
using System;
using UniRx;
using UnityEngine;

namespace NotTwice.Patterns.State.Runtime
{
	[CreateAssetMenu(fileName = "StateManager", menuName = "NotTwice/Patterns/State/StateManager")]
	public class NTStateManager : ScriptableObject, INTStateManager
	{
		[Expandable]
		public NTState InitialState;

		private INTState _currentState;

		// Observable exposant l'état courant
		public ReactiveProperty<INTState> CurrentState { get; private set; }

		private IDisposable _updateObserver;

		public void Initialize()
		{
			CurrentState = new ReactiveProperty<INTState>();

			if (InitialState != null)
			{
				CurrentState.Value = InitialState;
			}

			StartUpdate();
		}

		private void StartUpdate()
		{
			Observable.EveryUpdate()
				.Subscribe(_ =>
				{
					_currentState?.Execute();
				});	
		}

		private void StopUpdate()
		{
			_updateObserver?.Dispose();
			_updateObserver = null;
		}

		public void TransitionToState(NTState newState)
		{
			if (_currentState != null && _currentState.Equals(newState))
			{
				return;
			}

			StopUpdate();

			_currentState?.Exit();
			_currentState = newState;
			_currentState?.Enter();
			CurrentState.Value = _currentState;

			StartUpdate();
		}

		public void Clear()
		{
			StopUpdate();
		}
	}
}
