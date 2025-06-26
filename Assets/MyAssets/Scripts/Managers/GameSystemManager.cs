using UnityEngine;

namespace MyAssets
{
    public class GameSystemManager : MonoBehaviour
    {

        private void Awake()
        {
            InputManager.Initialize();
            DontDestroyOnLoad(gameObject);
        }

        private void OnDisable()
        {
            InputManager.Shutdown();
        }
    }
}
