using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    // ゲームクリアイベントを管理するクラス
    public class GameClearEvent : MonoBehaviour
    {
        [SerializeField]
        private List<EventUIObject> mEventList = new List<EventUIObject>();

        [SerializeField]
        private RectTransform       mEvenEndUI;
        private Text                mEventEndText;

        private int                 mEventClearCount;


        private Timer               mEventEndTimer = new Timer();

        private bool                mIsEventEndAction;

        private void Awake()
        {
            // UIのテキストコンポーネントを取得
            if (mEvenEndUI != null)
            {
                mEventEndText = mEvenEndUI.GetComponentInChildren<Text>();
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mEventClearCount = 0;
            mEvenEndUI?.gameObject.SetActive(false);
            mEventEndTimer.OnEnd += EventEndAction;

            BGMPlayerManager.Instance.BGMManager.Stop();
        }

        // Update is called once per frame
        private void Update()
        {
            mEventEndTimer.Update(Time.unscaledDeltaTime);
            mEventEndText.text = $"タイトルに戻ります\n{(int)mEventEndTimer.Current}";

            if(!mIsEventEndAction)
            {
                //イベント終了に必要なUIの数をカウント
                for (int i = 0; i < mEventList.Count; i++)
                {
                    if (mEventList[i].IsEventEnd)
                    {
                        mEventClearCount++;
                    }
                }
                //もしカウントがイベント終了に必要な数と同じなら
                if (mEventClearCount == mEventList.Count)
                {
                    BGMPlayerManager.Instance.BGMManager.Play(BGMManager.BGMList.eClear, false);
                    mIsEventEndAction = true;
                    mEventEndTimer.Start(3.0f);
                    mEvenEndUI?.gameObject.SetActive(true);
                }
                //まだ終わらなかったら
                else
                {
                    //リセット
                    mEventClearCount = 0;
                }

            }
        }

        private void EventEndAction()
        {
            LoadSceneManager.LoadScene(0);
        }
    }
}
