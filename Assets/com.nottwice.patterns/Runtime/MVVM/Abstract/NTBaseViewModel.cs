using NotTwice.Patterns.DependancyRegistration.Runtime;

namespace NotTwice.Patterns.MVVM.Runtime.Abstract
{
    public class NTBaseViewModel
    {
        protected readonly NTDependancyContainer Container;

        public NTBaseViewModel(NTDependancyContainer container)
        {
            Container = container;
        }
    }
}
