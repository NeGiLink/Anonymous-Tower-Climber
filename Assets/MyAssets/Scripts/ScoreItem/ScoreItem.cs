using UnityEngine;

namespace MyAssets
{
    //�X�R�A�A�C�e���ɃA�^�b�`����N���X
    //�X�R�A�擾���̏������s��
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
