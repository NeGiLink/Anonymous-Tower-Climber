using UnityEngine;

namespace MyAssets
{
    // ƒQ[ƒ€‚ÌŠÔ‚ğŠÇ—‚·‚éƒNƒ‰ƒX
    public class GameTimeManager
    {
        public static void SetTimeScale(float timeScale)
        {
            float scale = Mathf.Clamp(timeScale, 0f, 1f);
            Time.timeScale = scale;
        }
    }
}
