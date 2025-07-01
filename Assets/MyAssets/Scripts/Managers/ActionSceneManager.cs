using UnityEngine;

namespace MyAssets
{
    // アクションシーンのイベントを管理するクラス
    public class ActionSceneManager : MonoBehaviour
    {

        protected bool mGameEventing;

        public bool GameEventing
        {
            get => mGameEventing;
            set
            {
                mGameEventing = value;
                if (mGameEventing)
                {
                    GameTimeManager.SetTimeScale(0f);
                }
                else
                {
                    GameTimeManager.SetTimeScale(1f);
                }
            }
        }
    }
}
