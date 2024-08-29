namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
    /// <summary>
    /// Defines a command interface with methods for execution, checking if it can be executed, and undoing the command.
    /// </summary>
    public interface INTCommand
    {
        /// <summary>
        /// Executes the command with the specified arguments.
        /// </summary>
        /// <param name="args">An array of objects representing the arguments required for execution.</param>
        void Execute(params object[] args);

        /// <summary>
        /// Determines whether the command can be executed with the specified arguments.
        /// </summary>
        /// <param name="args">An array of objects representing the arguments to check.</param>
        /// <returns><c>true</c> if the command can be executed with the given arguments; otherwise, <c>false</c>.</returns>
        bool CanExecute(params object[] args);

        /// <summary>
        /// Undoes the command with the specified arguments.
        /// </summary>
        /// <param name="args">An array of objects representing the arguments required to undo the command.</param>
        void Undo(params object[] args);
    }
}