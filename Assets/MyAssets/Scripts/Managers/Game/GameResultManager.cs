namespace MyAssets
{
    public enum GameResult
    {
        eNone,
        ePose,
        eWin,
        eLose,
    }
    // �Q�[���̌��ʂ��Ǘ�����N���X
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
