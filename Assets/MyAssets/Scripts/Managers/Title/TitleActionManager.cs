using UnityEngine;

namespace MyAssets
{
    // �^�C�g���V�[���̃A�N�V�������Ǘ�����N���X
    public class TitleActionManager : ActionSceneManager
    {
        [SerializeField]
        private FadeOutPanelLifeView    mFadePanel;

        private Canvas                  mCanvas;

        private void Awake()
        {
            mCanvas = FindAnyObjectByType<Canvas>();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //�Q�[���J�n���o�ǉ�
            if (mCanvas != null)
            {
                FadeOutPanelLifeView panel = Instantiate(mFadePanel, mCanvas.transform);
                panel.SetFadeEventWaitCount(0.5f);
            }

            BGMPlayerManager.Instance.BGMManager.Stop();
        }
    }
}
