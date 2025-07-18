using UnityEngine;

namespace MyAssets
{
    // ゲームの時間を管理するクラス
    public class GameTimeManager
    {
        public static void SetTimeScale(float timeScale)
        {
            float scale = Mathf.Clamp(timeScale, 0f, 1f);
            Time.timeScale = scale;
        }
    }
}
