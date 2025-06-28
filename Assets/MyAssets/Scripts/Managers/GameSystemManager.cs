using UnityEngine;

namespace MyAssets
{
    public enum GameState
    {
        eNone,
        eGame,
        ePause,
    }
    public class GameSystemManager : MonoBehaviour
    {

        private void Awake()
        {
            InputManager.Initialize();
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            InputManager.SetLockedMouseMode();
        }

        private void OnDisable()
        {
            InputManager.Shutdown();
        }
    }

    public static class PlayerLifeManager
    {
        private static int mLife = 3;

        public static int Life => mLife;

        public static int mPastLife;

        public static int PastLife => mPastLife;

        public static void Reset()
        {
            mLife = 3;
            mPastLife = mLife;
        }

        public static void DecreaseLife()
        {
            mPastLife = mLife;
            mLife--;
            if(mLife < -99)
            {
                mLife = -99;
            }
        }

        public static void LifeUpdate()
        {
            mPastLife = mLife;
        }
    }
}
