using UnityEngine;

namespace MyAssets
{
    public enum GameResult
    {
        eNone,
        eWin,
        eLose,
    }
    public static class GameResultManager
    {
        private static GameResult mGameResult = GameResult.eNone;
        public static GameResult GetGameResult()
        {
            return mGameResult;
        }
        public static void SetGameResult(GameResult result)
        {
            mGameResult = result;
        }
        public static void ResetGameResult()
        {
            mGameResult = GameResult.eNone;
        }
    }
}
