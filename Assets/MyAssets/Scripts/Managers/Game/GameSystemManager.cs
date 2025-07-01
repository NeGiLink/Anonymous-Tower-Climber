using UnityEngine;

namespace MyAssets
{
    // ゲームシステム全体を管理するクラス
    public class GameSystemManager : MonoBehaviour
    {
        private static GameSystemManager    instance;

        public static GameSystemManager     Instance => instance;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);

            InputManager.Initialize();
        }

        private void Start()
        {
            InputManager.SetLockedMouseMode();
        }
    }

    // プレイヤーのライフを管理するクラス
    public static class PlayerLifeManager
    {
        private static int  mLife = 3;

        public static int   Life => mLife;

        public static int   mPastLife;

        public static int   PastLife => mPastLife;

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
