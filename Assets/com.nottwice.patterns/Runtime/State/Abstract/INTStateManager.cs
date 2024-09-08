using UniRx;

namespace NotTwice.Patterns.State.Runtime.Abstract
{
	public interface INTStateManager
	{
		ReactiveProperty<INTState> CurrentState { get; }

		void TransitionToState(NTState newState);
	}
}