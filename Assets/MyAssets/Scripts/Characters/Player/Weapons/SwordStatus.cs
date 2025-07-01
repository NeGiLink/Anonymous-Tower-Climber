using UnityEngine;

namespace MyAssets
{
    //剣のステータスを管理するクラス
    public class SwordStatus : MonoBehaviour
    {
        [SerializeField]
        private float mKnockbackForce;

        public float KnockbackForce => mKnockbackForce;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //敵にダメージを与える処理
            if(collision.TryGetComponent<EnemyDamageController>(out var damageController))
            {
                //プレイヤーにダメージを与える
                damageController.OnDamage(new Vector2(0, mKnockbackForce));
                Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
                knockbackDirection += Vector2.up;
                damageController.OnDamage(knockbackDirection);
                if(!damageController.Invincible)
                {
                    SystemSEManager.Instance.OnPlay((int)SystemSEManager.SEList_System.EnemyDead);
                }
            }
        }
    }
}
