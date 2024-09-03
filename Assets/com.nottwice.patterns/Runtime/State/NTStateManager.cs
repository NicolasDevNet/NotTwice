using NaughtyAttributes;
using NotTwice.Patterns.State.Runtime.Abstract;
using UniRx;
using UnityEngine;

namespace NotTwice.Patterns.State.Runtime
{
    [AddComponentMenu("NotTwice/Patterns/State/StateManager")]
    public class NTStateManager : MonoBehaviour
    {
        [Expandable]
        public NTState InitialState;

        private INTState _currentState;

        // Observable exposant l'état courant
        public ReactiveProperty<INTState> CurrentState { get; private set; }

        private void Start()
        {
            CurrentState = new ReactiveProperty<INTState>();

            if(InitialState != null)
            {
                CurrentState.Value = InitialState;
            }
        }

        private void Update()
        {
            _currentState?.Execute();
        }

        public void TransitionToState(NTState newState)
        {
            if (_currentState != null && _currentState.Equals(newState))
            {
                return;
            }

            _currentState?.Exit();
            _currentState = newState;
            _currentState?.Enter();
            CurrentState.Value = _currentState;
        }
    }
}
