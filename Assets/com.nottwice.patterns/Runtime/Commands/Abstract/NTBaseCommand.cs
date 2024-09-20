using NotTwice.Patterns.DependancyRegistration.Runtime;

namespace NotTwice.Patterns.Commands.Runtime.Abstract
{
    /// <summary>
    /// NTBaseCommand is a base class that serves as the base for all command objects in the Command pattern.
    /// </summary>
    public class NTBaseCommand
    {
        protected NTDependancyContainer Container { get; }

        public NTBaseCommand(NTDependancyContainer container)
        {
            Container = container;
        }     
    }
}