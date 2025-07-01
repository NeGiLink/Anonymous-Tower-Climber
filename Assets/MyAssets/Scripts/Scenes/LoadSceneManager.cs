using UnityEngine.SceneManagement;

namespace MyAssets
{
    public enum SceneList
    {
        eNone = -1,
        eTitle,
        eGame
    }
    // SceneManager‚ðŠÇ—‚·‚éƒNƒ‰ƒX
    public static class LoadSceneManager
    {

        private static int  mCurrnetSceneIndex;
        public static int   CurrnetSceneIndex => mCurrnetSceneIndex;

        private static int  mPastSceneIndex;

        public static int   PastSceneIndex => mPastSceneIndex;
        public static void LoadScene(int id)
        {
            mPastSceneIndex = SceneManager.GetActiveScene().buildIndex;
            mCurrnetSceneIndex = id;
            SceneManager.LoadScene(id);
        }

        public static void LoadScene(string id)
        {
            mPastSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(id);
            mCurrnetSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }

        public static void ReloadScene()
        {
            mPastSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            mCurrnetSceneIndex = SceneManager.GetActiveScene().buildIndex;
        }
    }
}
