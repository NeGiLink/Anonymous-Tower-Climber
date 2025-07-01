using UnityEngine;

namespace MyAssets
{
    // タイトルシーンのアクションを管理するクラス
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
            //ゲーム開始演出追加
            if (mCanvas != null)
            {
                FadeOutPanelLifeView panel = Instantiate(mFadePanel, mCanvas.transform);
                panel.SetFadeEventWaitCount(0.5f);
            }

            BGMPlayerManager.Instance.BGMManager.Stop();
        }
    }
}
