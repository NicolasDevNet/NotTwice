using Cysharp.Threading.Tasks;

namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
    public interface INTCommandInvoker
    {
        void ExecuteCommand<T>(params object[] args) where T : NTBaseCommand;
        UniTask ExecuteCommandAsync<T>(params object[] args) where T : NTBaseCommand;
        void UndoCommand(params object[] args);
        UniTask UndoCommandAsync(params object[] args);
    }
}