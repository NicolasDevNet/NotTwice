using UnityEngine;

namespace Assets.com.nottwice.components.Runtime.UI
{
    [AddComponentMenu("NotTwice/UI/NotDestroyableInstance")]
    public class NotDestroyableInstance : MonoBehaviour
    {
        public static NotDestroyableInstance Instance;

        private void Start()
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
