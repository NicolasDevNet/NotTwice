namespace NotTwice.Patterns.State.Runtime.Abstract
{
    public interface INTState
    {
        void Enter();
        void Execute();
        void Exit();
    }
}
