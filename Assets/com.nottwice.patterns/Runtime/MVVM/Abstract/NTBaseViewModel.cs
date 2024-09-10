using NotTwice.Patterns.DependancyRegistration.Runtime;

namespace NotTwice.Patterns.MVVM.Runtime.Abstract
{
    public class NTBaseViewModel<TModel>
    {
        protected readonly NTDependancyContainer Container;
        protected readonly TModel Model;

        public NTBaseViewModel(NTDependancyContainer container, TModel model)
        {
            Container = container;
            Model = model;
        }

        public NTBaseViewModel(NTDependancyContainer container)
        {
            Container = container;
        }
    }
}
