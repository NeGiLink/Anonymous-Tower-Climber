using UnityEngine;

namespace MyAssets
{
    //スコアアイテムにアタッチするクラス
    //スコア取得時の処理を行う
    public class ScoreItem : MonoBehaviour
    {
        [SerializeField]
        private FXController    mFxController;

        private int             mScore = 10;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.GetComponent<PlayerInput>() != null)
            {
                if(mFxController != null)
                {
                    Instantiate(mFxController,transform.position,Quaternion.identity);
                }
                PlayerSEManager seManager = collision.GetComponent<PlayerSEManager>();
                GameScoreManager.AddScore(mScore);
                seManager.OnPlay((int)PlayerSEManager.SEList_Player.eGetItem);
                Destroy(gameObject);
            }
        }
    }
}
