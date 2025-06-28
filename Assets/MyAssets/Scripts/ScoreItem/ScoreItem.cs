using UnityEngine;

namespace MyAssets
{
    public class ScoreItem : MonoBehaviour
    {
        private int mScore = 10;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<PlayerInput>() != null)
            {
                GameScoreManager.AddScore(mScore);
                Destroy(gameObject);
            }
        }
    }
}
