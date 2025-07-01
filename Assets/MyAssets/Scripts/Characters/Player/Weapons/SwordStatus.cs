using UnityEngine;

namespace MyAssets
{
    //���̃X�e�[�^�X���Ǘ�����N���X
    public class SwordStatus : MonoBehaviour
    {
        [SerializeField]
        private float mKnockbackForce;

        public float KnockbackForce => mKnockbackForce;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            //�G�Ƀ_���[�W��^���鏈��
            if(collision.TryGetComponent<EnemyDamageController>(out var damageController))
            {
                //�v���C���[�Ƀ_���[�W��^����
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
