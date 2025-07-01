using System;
using UnityEngine;

namespace MyAssets
{
    // �Q�[���̌��ʂ��Ǘ�����N���X
    public static class GameScoreManager
    {
        private static int          mMaxTotalScore = 9999999;

        private static int          mTotalScore;

        public static int           TotalScore => mTotalScore;

        public static event Action  OnEvent;

        public static void AddScore(int score)
        {
            mTotalScore += score;
            if(mTotalScore >= mMaxTotalScore)
            {
                mTotalScore = mMaxTotalScore;
            }
            OnEvent?.Invoke();
        }

        public static void Reset() { mTotalScore = 0; }
    }
    // �Q�[���̃A�N�V�����V�[�����Ǘ�����N���X

    public class GameActionSceneManager : ActionSceneManager
    {
        private Canvas                  mCanvas;

        [SerializeField]
        private GameClearEvent          mClearEvent;

        [SerializeField]
        private GameOverEvent           mOverEvent;


        [SerializeField]
        private FadeOutPanelLifeView    mFadePanel;
        [SerializeField]
        private PlayerLifeViewEvent     mPlayerLifeView;


        [SerializeField]
        private float                   mGameTime;

        public float                    GameTime => mGameTime;

        private void Awake()
        {
            mCanvas = FindAnyObjectByType<Canvas>();
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //�Q�[���J�n���o�ǉ�
            if(mCanvas != null)
            {
                GameObject obj = Instantiate(mFadePanel, mCanvas.transform).gameObject;
                Instantiate(mPlayerLifeView, obj.transform);
            }

            BGMPlayerManager.Instance.BGMManager.Stop();
            GameResultManager.ResetGameResult();
            GameScoreManager.Reset();
            if(LoadSceneManager.CurrnetSceneIndex != LoadSceneManager.PastSceneIndex)
            {
                PlayerLifeManager.Reset();
            }
        }

        private void Update()
        {
            if(GameResultManager.GetGameResult() != GameResult.eNone) { return; }
            mGameTime -= Time.deltaTime;
            if (mGameTime <= 0)
            {
                mGameTime = 0;
                // �Q�[�����Ԃ�0�ȉ��ɂȂ�����Q�[���I�[�o�[
                GameResultManager.SetGameResult(GameResult.eLose);
                PlayerDamageController playerDamageController = FindAnyObjectByType<PlayerDamageController>();
                if (playerDamageController != null)
                {
                    // �v���C���[�Ƀ_���[�W��^����
                    playerDamageController.OnDamage(Vector2.up * 10f);
                }
            }
        }

        public void RunClearEvent()
        {
            if (GameResultManager.GetGameResult() != GameResult.eWin) { return; }
            Instantiate(mClearEvent, mCanvas.transform);
        }

        public void RunOverEvent()
        {
            if (GameResultManager.GetGameResult() != GameResult.eLose) { return; }
            Instantiate(mOverEvent, mCanvas.transform);
        }
    }
}
