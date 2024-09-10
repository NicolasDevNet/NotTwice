using NaughtyAttributes;
using UnityEngine;

namespace NotTwice.Patterns.MVVM.Runtime.Abstract
{
    public abstract class NTBaseView : MonoBehaviour
    {
        [ReadOnly]
        public bool IsInitialized;

        public abstract void Initialize();
    }
}
