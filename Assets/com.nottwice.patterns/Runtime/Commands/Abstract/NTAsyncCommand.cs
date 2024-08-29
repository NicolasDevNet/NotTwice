using Cysharp.Threading.Tasks;

namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
    /// <summary>
    /// NTAsyncCommand is an abstract class that serves as the base for all asynchronous commands in the Command pattern.
    /// This class extends NTBaseCommand and implements the INTAsyncCommand interface, providing the structure for executing,
    /// checking the feasibility of execution, and undoing asynchronous commands.
    /// </summary>
    public abstract class NTAsyncCommand : NTBaseCommand, INTAsyncCommand
    {
        /// <summary>
        /// Executes the asynchronous command with the provided parameters.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed for the command execution.</param>
        /// <returns>A UniTask representing the asynchronous operation.</returns>
        public abstract UniTask ExecuteAsync(params object[] args);

        /// <summary>
        /// Determines whether the asynchronous command can be executed based on the provided parameters.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed to check command eligibility.</param>
        /// <returns>A UniTask returning true if the command can be executed; otherwise, false.</returns>
        public abstract UniTask<bool> CanExecuteAsync(params object[] args);

        /// <summary>
        /// Reverts the previously executed asynchronous command, using the provided parameters if necessary.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed for undoing the command.</param>
        /// <returns>A UniTask representing the asynchronous operation.</returns>
        public abstract UniTask UndoAsync(params object[] args);
    }
}
