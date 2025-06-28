using System;
using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    public class FadeOutPanelLifeView : MonoBehaviour
    {
        private Image mFadeOutPanel;

        private Timer mFadeOutTimer = new Timer();

        private float mFadeEventWaitCount = 4.0f;

        private bool mFadeStart;

        private float mFadeSpeed = 10.0f;


        private GameActionSceneManager mGameActionSceneManager;

        private void Awake()
        {
            mFadeOutPanel = GetComponent<Image>();
        }

        private void Start()
        {
            mGameActionSceneManager = FindAnyObjectByType<GameActionSceneManager>();
            if (mGameActionSceneManager != null)
            {
                mGameActionSceneManager.GameEventing = true;
            }

            mFadeOutTimer.Start(mFadeEventWaitCount);
            mFadeOutTimer.OnEnd += FadeStart;

            mFadeStart = false;
        }

        public void FadeStart()
        {
            mFadeEventWaitCount = 0.0f;
            mFadeStart = true;
        }

        private void Update()
        {
            mFadeOutTimer.Update(Time.unscaledDeltaTime);

            if(mFadeStart)
            {
                mFadeOutPanel.rectTransform.localScale = Vector3.Lerp(mFadeOutPanel.rectTransform.localScale,Vector3.zero,mFadeSpeed * Time.unscaledDeltaTime);
                
                if(mFadeOutPanel.rectTransform.localScale.magnitude <= 0.1f)
                {
                    mFadeStart = false;
                    mGameActionSceneManager.GameEventing = false;
                    Destroy(gameObject);
                }
            }
        }
    }
}
