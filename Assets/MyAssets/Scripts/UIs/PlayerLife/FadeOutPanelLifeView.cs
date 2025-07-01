using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    // プレイヤーのライフが0になったときにフェードアウトするパネルのビュー
    public class FadeOutPanelLifeView : MonoBehaviour
    {
        private Image mFadeOutPanel;

        private Timer mFadeOutTimer = new Timer();

        private float mFadeEventWaitCount = 4.0f;

        public void SetFadeEventWaitCount(float count)
        {
            mFadeEventWaitCount = count;
        }

        private bool mFadeStart;

        private float mFadeSpeed = 10.0f;

        public void SetFadeSpeed(float speed)
        {
            mFadeSpeed = speed;
        }


        private ActionSceneManager mActionSceneManager;

        private void Awake()
        {
            mFadeOutPanel = GetComponent<Image>();
        }

        private void Start()
        {
            GameResultManager.SetGameResult(GameResult.ePose);
            mActionSceneManager = FindAnyObjectByType<ActionSceneManager>();
            if (mActionSceneManager != null)
            {
                mActionSceneManager.GameEventing = true;
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
                    GameResultManager.SetGameResult(GameResult.eNone);
                    mFadeStart = false;
                    mActionSceneManager.GameEventing = false;
                    Destroy(gameObject);
                    BGMPlayerManager.Instance.PlayBGM();
                }
            }
        }
    }
}
