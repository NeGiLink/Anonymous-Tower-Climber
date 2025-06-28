using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MyAssets
{
    [RequireComponent(typeof(ButtonController))]
    public class DialogBox : MonoBehaviour
    {
        private Text mTitleText;

        private List<Button> mButtons = new List<Button>();

        private ButtonImageList mButtonImageList;

        private int mDisideIndex;

        private int mPastDisideIndex;

        private GameActionSceneManager mGameActionSceneManager;

        public void SetDialog(string title, UnityAction yesCall, UnityAction noCall)
        {
            mTitleText.text = title;
            mButtons[0].onClick.AddListener(yesCall);
            mButtons[1].onClick.AddListener(noCall);
        }

        private void Awake()
        {

            mGameActionSceneManager = FindAnyObjectByType<GameActionSceneManager>();
            if (mGameActionSceneManager != null)
            {
                mGameActionSceneManager.GameEventing = true;
            }
        }
    }
}
