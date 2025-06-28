using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    public class EraseUIButton : MonoBehaviour
    {


        private Button mButton;

        private GameActionSceneManager mGameActionSceneManager;

        private void Awake()
        {
            mButton = GetComponent<Button>();

            mGameActionSceneManager = FindAnyObjectByType<GameActionSceneManager>();
        }

        private void Start()
        {
            if (mButton != null)
            {
                mButton.onClick.AddListener(Action);
            }
        }

        private void Action()
        {
            GameObject p = transform.parent.gameObject;
            if (p != null)
            {
                Destroy(p);
                mGameActionSceneManager = FindAnyObjectByType<GameActionSceneManager>();
                if (mGameActionSceneManager != null)
                {
                    mGameActionSceneManager.GameEventing = false;
                }
            }
        }
    }
}
