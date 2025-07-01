using UnityEngine;

namespace MyAssets
{
    // �Q�[���̎��Ԃ��Ǘ�����N���X
    public class GameTimeManager
    {
        public static void SetTimeScale(float timeScale)
        {
            float scale = Mathf.Clamp(timeScale, 0f, 1f);
            Time.timeScale = scale;
        }
    }
}
