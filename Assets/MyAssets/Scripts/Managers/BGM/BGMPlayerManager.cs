using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyAssets
{
    // BGM‚ÌÄ¶‚ðŠÇ—‚·‚éƒNƒ‰ƒX
    public class BGMPlayerManager : MonoBehaviour
    {
        private static BGMPlayerManager instance;

        public static BGMPlayerManager  Instance => instance;

        private BGMManager              mBGMManager;

        public BGMManager               BGMManager => mBGMManager;

        private float mVolue = 1.0f;

        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
                return;
            }
            instance = this;
            DontDestroyOnLoad(gameObject);

            mBGMManager = GetComponent<BGMManager>();
        }

        public void PlayBGM()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                mBGMManager.Play(BGMManager.BGMList.eTitle, true);
            }
            else
            {
                mBGMManager.Play(BGMManager.BGMList.eGame, true);
            }
        }
    }
}
