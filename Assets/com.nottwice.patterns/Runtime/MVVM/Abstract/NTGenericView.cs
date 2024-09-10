using NaughtyAttributes;
using NotTwice.Patterns.DependancyRegistration.Runtime;
using NotTwice.Patterns.MVVM.Runtime.Interfaces;
using System;

namespace NotTwice.Patterns.MVVM.Runtime.Abstract
{
    public abstract class NTGenericView<TModel, TViewModelContract, TViewModelConcrete> : NTBaseView
        where TViewModelContract : INTViewModel
        where TViewModelConcrete : NTBaseViewModel<TModel>, TViewModelContract
    {
        public TModel Model;

        [Required, Expandable]
        public NTDependancyContainer Container;

        protected TViewModelContract ViewModel { get; private set; }

        public override void Initialize()
        {
            ViewModel = (TViewModelConcrete)Activator.CreateInstance(typeof(TViewModelConcrete), Container, Model);

            IsInitialized = true;
        }
    }
}
