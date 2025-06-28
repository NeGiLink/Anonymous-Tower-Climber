using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    public class GameTimer : MonoBehaviour
    {
        private GameActionSceneManager mGameActionSceneManager;

        private Text mTimetext;

        private void Awake()
        {
            // Find the GameActionSceneManager in the scene
            mGameActionSceneManager = FindAnyObjectByType<GameActionSceneManager>();
            if (mGameActionSceneManager == null)
            {
                Debug.LogError("GameActionSceneManager not found in the scene.");
            }
            mTimetext = GetComponentInChildren<Text>();
            if (mTimetext == null)
            {
                Debug.LogError("Text component not found on this GameObject.");
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if(mGameActionSceneManager == null || mTimetext == null)
            {
                return; // Exit if the manager or text component is not set
            }
            // Update the timer text with the remaining game time
            int remainingTime = (int)mGameActionSceneManager.GameTime;
            mTimetext.text = $"Time : {remainingTime}";
        }
    }
}
