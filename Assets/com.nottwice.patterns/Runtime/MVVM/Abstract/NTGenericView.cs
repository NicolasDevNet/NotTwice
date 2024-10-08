using NaughtyAttributes;
using NotTwice.Patterns.DependancyRegistration.Runtime;
using NotTwice.Patterns.MVVM.Runtime.Interfaces;
using System;
using System.Linq;

namespace NotTwice.Patterns.MVVM.Runtime.Abstract
{
    public abstract class NTGenericView<TViewModelContract> : NTBaseView
        where TViewModelContract : INTViewModel
    {
        [Required, Expandable]
        public NTDependancyContainer Container;

        protected TViewModelContract ViewModel { get; private set; }

        public override void Initialize()
        {
			var viewModelType = FindConcreteViewModelType();

			// Crée une instance du ViewModel concret avec les paramètres
			ViewModel = (TViewModelContract)Activator.CreateInstance(viewModelType, args: new object[] { Container });

			IsInitialized = true;
		}

		private Type FindConcreteViewModelType()
		{
			// Trouve tous les types qui implémentent l'interface `TViewModelContract`
			var viewModelType = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(a => a.GetTypes())
				.FirstOrDefault(t => typeof(TViewModelContract).IsAssignableFrom(t)
									 && t.IsClass
									 && !t.IsAbstract);

			if (viewModelType == null)
			{
				throw new InvalidOperationException($"No concrete ViewModel type found that implements {typeof(TViewModelContract).Name}");
			}

			return viewModelType;
		}
	}
}
