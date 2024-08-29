using Cysharp.Threading.Tasks;

namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
    /// <summary>
    /// Defines an asynchronous command interface with methods for executing, checking if it can be executed, and undoing the command asynchronously.
    /// </summary>
    public interface INTAsyncCommand
    {
        /// <summary>
        /// Executes the command asynchronously with the specified arguments.
        /// </summary>
        /// <param name="args">An array of objects representing the arguments required for execution.</param>
        /// <returns>A <see cref="UniTask"/> representing the asynchronous operation.</returns>
        UniTask ExecuteAsync(params object[] args);

        /// <summary>
        /// Determines whether the command can be executed asynchronously with the specified arguments.
        /// </summary>
        /// <param name="args">An array of objects representing the arguments to check.</param>
        /// <returns>A <see cref="UniTask{TResult}"/> that resolves to a boolean indicating whether the command can be executed with the given arguments.</returns>
        UniTask<bool> CanExecuteAsync(params object[] args);

        /// <summary>
        /// Undoes the command asynchronously with the specified arguments.
        /// </summary>
        /// <param name="args">An array of objects representing the arguments required to undo the command.</param>
        /// <returns>A <see cref="UniTask"/> representing the asynchronous operation.</returns>
        UniTask UndoAsync(params object[] args);
    }
}