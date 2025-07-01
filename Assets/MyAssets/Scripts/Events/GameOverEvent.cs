using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    // �Q�[���I�[�o�[�C�x���g���Ǘ�����N���X
    public class GameOverEvent : MonoBehaviour
    {
        [SerializeField]
        private List<EventUIObject> mEventList = new List<EventUIObject>();

        private int                 mEventClearCount;


        private Timer               mEventEndTimer = new Timer();

        private bool                mIsEventEndAction;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mEventClearCount = 0;
            mEventEndTimer.OnEnd += EventEndAction;

            mIsEventEndAction = false;

            BGMPlayerManager.Instance.BGMManager.Stop();
        }

        // Update is called once per frame
        private void Update()
        {
            mEventEndTimer.Update(Time.unscaledDeltaTime);
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
                    BGMPlayerManager.Instance.BGMManager.Play(BGMManager.BGMList.eOver, false);
                    mIsEventEndAction =true;
                    mEventEndTimer.Start(3.0f);
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
            LoadSceneManager.ReloadScene();
        }
    }
}
