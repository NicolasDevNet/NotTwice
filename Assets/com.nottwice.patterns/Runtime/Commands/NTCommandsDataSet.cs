using NotTwice.Patterns.Commands.Runtime.Abstract;
using NotTwice.ScriptableObjects.Runtime.Collections;
using UnityEngine;

namespace Assets.com.nottwice.patterns.Runtime.Commands
{
    [CreateAssetMenu(fileName = "CommandsDataSet", menuName = "NotTwice/Patterns/Commands/Collections/CommandsDataSet")]
    public class NTCommandsDataSet : NTScriptableDataSet<NTBaseCommand>
    {
        public T FindCommand<T>(string commandName = null)
            where T : NTBaseCommand
        {
            if (string.IsNullOrEmpty(commandName))
            {
                return DataSet.Find(p => p is T) as T;
            }

            return DataSet.Find(p => p.Name == commandName) as T;
        }
    }
}
