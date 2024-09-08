using Cysharp.Threading.Tasks;
using NotTwice.ScriptableObjects.Runtime.Variables.Typed;

namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
	public interface INTCommandInvoker
	{
		void EnsureStringVariableNameIsValid(NTStringVariable commandName);
		void ExecuteCommand(NTBaseCommand command);
		void ExecuteCommand<T>(NTStringVariable commandName) where T : NTBaseCommand;
		void ExecuteCommand<T>(params object[] args) where T : NTBaseCommand;
		void ExecuteCommand<T>(string commandName) where T : NTBaseCommand;
		UniTask ExecuteCommandAsync(NTBaseCommand command);
		UniTask ExecuteCommandAsync<T>(NTStringVariable commandName) where T : NTBaseCommand;
		UniTask ExecuteCommandAsync<T>(params object[] args) where T : NTBaseCommand;
		UniTask ExecuteCommandAsync<T>(string commandName) where T : NTBaseCommand;
		void UndoCommand();
		void UndoCommand<T>(params object[] args);
		UniTask UndoCommandAsync();
		UniTask UndoCommandAsync<T>(params object[] args);
	}
}