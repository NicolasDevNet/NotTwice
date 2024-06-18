using UnityEngine;

namespace NotTwice.Components.Runtime.GameObjects
{
    /// <summary>
    /// Component class preventing a game object from being destroyed
    /// </summary>
    [AddComponentMenu("NotTwice/GameObjects/NotDestroyableInstance")]
    [DisallowMultipleComponent]
    public class NTNotDestroyableInstance : MonoBehaviour
    {
        /// <summary>
        /// Instance of the game object stored in memory
        /// </summary>
        public static NTNotDestroyableInstance Instance { get; private set; }

        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
