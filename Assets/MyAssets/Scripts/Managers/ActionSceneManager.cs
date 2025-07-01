using UnityEngine;

namespace MyAssets
{
    // �A�N�V�����V�[���̃C�x���g���Ǘ�����N���X
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
