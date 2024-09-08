using UnityEngine;

namespace NotTwice.Patterns.State.Runtime.Abstract
{
	public abstract class NTState : ScriptableObject, INTState
    {
        public NTStateDataSet ComparareDataSet;

        public abstract void Enter();

        public abstract void Execute();

        public abstract void Exit();

        public bool IsValid()
        {
            return ComparareDataSet != null && ComparareDataSet.IsValid(this);
        }
    }
}
