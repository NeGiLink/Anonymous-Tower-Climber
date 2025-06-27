using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    public class PlayerDamageController : MonoBehaviour
    {

        private Rigidbody2D mRigidbody2D;

        private Collider2D mCollider2D;

        private float mDestroyDelay = 5f;

        private List<MonoBehaviour> mMonoBehaviour = new List<MonoBehaviour>();

        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mCollider2D = GetComponent<Collider2D>();

            MonoBehaviour[] mono = GetComponents<MonoBehaviour>();
            for (int i = 0; i < mono.Length; i++)
            {
                if (mono[i] != this)
                {
                    mMonoBehaviour.Add(mono[i]);
                }
            }
        }

        public void OnDamage(Vector2 force)
        {
            mRigidbody2D.AddForce(force, ForceMode2D.Impulse);
            mCollider2D.isTrigger = true;
            //���̃N���X�ȊO��MonoBehaviour�𖳌���
            for (int i = 0; i < mMonoBehaviour.Count; i++)
            {
                if (mMonoBehaviour[i] != null)
                {
                    mMonoBehaviour[i].enabled = false;
                }
            }
            //�v���C���[��j�󂷂�
            Destroy(gameObject, mDestroyDelay);
            //�J�����̃^�[�Q�b�g��null�ɐݒ�
            FollowCamera followCamera = Camera.main.GetComponent<FollowCamera>();
            if (followCamera != null)
            {
                followCamera.SetTarget(null);
            }
        }
    }
}
