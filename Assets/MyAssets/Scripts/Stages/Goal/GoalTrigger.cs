using UnityEngine;

namespace MyAssets
{
    public class GoalTrigger : MonoBehaviour
    {
        private bool mIsGoal;

        private void Start()
        {
            mIsGoal = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (mIsGoal) { return; }
            if (collision.GetComponent<PlayerInput>() != null)
            {

                GameResultManager.SetGameResult(GameResult.eWin);
                GameActionSceneManager gameActionSceneManager = FindAnyObjectByType<GameActionSceneManager>();
                if(gameActionSceneManager != null)
                {
                    gameActionSceneManager.RunClearEvent();
                }
                mIsGoal = true;
            }
        }
    }
}
