using NotTwice.Patterns.State.Runtime.Abstract;
using NotTwice.ScriptableObjects.Runtime.Collections;
using System.Linq;
using UnityEngine;

namespace NotTwice.Patterns.State.Runtime
{
    [CreateAssetMenu(fileName = "StateDataSet", menuName = "NotTwice/Patterns/State/Collections/StateDataSet")]
    public class NTStateDataSet : NTScriptableDataSet<NTState>
    {
        public bool IsValid(NTState state)
        {
            return DataSet.Contains(state);
        }

        public bool IsValid(string id)
        {
            return DataSet.FirstOrDefault(p => p.GetInstanceID().Equals(id));
        }
    }
}
