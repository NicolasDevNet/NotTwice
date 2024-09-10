using NaughtyAttributes;
using NotTwice.Patterns.MVVM.Runtime.Abstract;
using UnityEngine;

namespace NotTwice.Patterns.MVVM.Runtime
{
    [AddComponentMenu("NotTwice/Patterns/MVVM/ViewsInitializer")]
    [DisallowMultipleComponent]
    public class NTViewsInitializer : MonoBehaviour
    {
        [ReadOnly]
        public NTBaseView[] Views;

        public void Start()
        {
            Views = GetComponentsInChildren<NTBaseView>();
        }

        public void Initialize()
        {
            foreach (NTBaseView view in Views)
            {
                view.Initialize();
            }
        }
    }
}
