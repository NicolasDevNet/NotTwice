using NotTwice.Patterns.DependancyRegistration.Runtime;
using System;

namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
    /// <summary>
    /// NTCommand is an abstract class that serves as the base for all synchronous commands in the Command pattern.
    /// It provides the structure for executing, checking the feasibility of execution, and undoing commands.
    /// </summary>
    public class NTCommand : NTBaseCommand, INTCommand
    {
        public NTCommand(NTDependancyContainer container) : base(container)
        {
        }

        /// <summary>
        /// Executes the command with the provided parameters.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed for the command execution.</param>
        public virtual void Execute(params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines whether the command can be executed based on the provided parameters.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed to check command eligibility.</param>
        /// <returns>True if the command can be executed; otherwise, false.</returns>
        public virtual bool CanExecute(params object[] args)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reverts the previously executed command, using the provided parameters if necessary.
        /// This method must be implemented by any subclass.
        /// </summary>
        /// <param name="args">An array of objects representing the parameters needed for undoing the command.</param>
        public virtual void Undo(params object[] args)
        {
            throw new NotImplementedException();
        }
    }
}
