using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyAssets
{
    // �Q�[���N���A�C�x���g���Ǘ�����N���X
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
            // UI�̃e�L�X�g�R���|�[�l���g���擾
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
            mEventEndText.text = $"�^�C�g���ɖ߂�܂�\n{(int)mEventEndTimer.Current}";

            if(!mIsEventEndAction)
            {
                //�C�x���g�I���ɕK�v��UI�̐����J�E���g
                for (int i = 0; i < mEventList.Count; i++)
                {
                    if (mEventList[i].IsEventEnd)
                    {
                        mEventClearCount++;
                    }
                }
                //�����J�E���g���C�x���g�I���ɕK�v�Ȑ��Ɠ����Ȃ�
                if (mEventClearCount == mEventList.Count)
                {
                    BGMPlayerManager.Instance.BGMManager.Play(BGMManager.BGMList.eClear, false);
                    mIsEventEndAction = true;
                    mEventEndTimer.Start(3.0f);
                    mEvenEndUI?.gameObject.SetActive(true);
                }
                //�܂��I���Ȃ�������
                else
                {
                    //���Z�b�g
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
