namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
    /// <summary>
    /// NTCommand is an abstract class that serves as the base for all synchronous commands in the Command pattern.
    /// It provides the structure for executing, checking the feasibility of execution, and undoing commands.
    /// </summary>
    public abstract class NTCommand : NTBaseCommand, INTCommand
    {
        /// <summary>
        /// Executes the command with the provided parameters.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed for the command execution.</param>
        public abstract void Execute(params object[] args);

        /// <summary>
        /// Determines whether the command can be executed based on the provided parameters.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed to check command eligibility.</param>
        /// <returns>True if the command can be executed; otherwise, false.</returns>
        public abstract bool CanExecute(params object[] args);

        /// <summary>
        /// Reverts the previously executed command, using the provided parameters if necessary.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed for undoing the command.</param>
        public abstract void Undo(params object[] args);
    }
}
