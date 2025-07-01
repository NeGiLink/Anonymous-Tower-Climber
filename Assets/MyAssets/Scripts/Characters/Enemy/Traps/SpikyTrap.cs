using UnityEngine;

namespace MyAssets
{
    // �X�p�C�N�g���b�v�̃N���X
    public class SpikyTrap : MonoBehaviour
    {
        private Transform     mSpiky;

        private Vector3       mActiveSpokyPos;

        private bool          mIsActiveSpiky;
        [SerializeField]
        private float         mSpeed;

        private BoxCollider2D mBoxCollider2D;

        private void Awake()
        {
            mSpiky = GetComponentInChildren<Transform>();
            mBoxCollider2D = GetComponentInChildren<BoxCollider2D>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mActiveSpokyPos = mSpiky.position + new Vector3(0, 1.0f,0);
            mBoxCollider2D.enabled = false; // ������Ԃł̓R���C�_�[�𖳌���
        }

        // Update is called once per frame
        void Update()
        {
            if(!mIsActiveSpiky)
            {
                Ray2D ray = new Ray2D(transform.position + new Vector3(0.5f,0.0f,0.0f), Vector2.up);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 3.0f, LayerMask.GetMask("DynamicObject"));
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    // Player��Ray�̐�ɂ���ꍇ�A�X�p�C�N��\��
                    mIsActiveSpiky = true;
                    mBoxCollider2D.enabled = true; // �R���C�_�[��L����
                }

                ray = new Ray2D(transform.position + new Vector3(-0.5f, 0.0f, 0.0f), Vector2.up);
                hit = Physics2D.Raycast(ray.origin, ray.direction, 3.0f, LayerMask.GetMask("DynamicObject"));
                if (hit.collider != null && hit.collider.CompareTag("Player"))
                {
                    // Player��Ray�̐�ɂ���ꍇ�A�X�p�C�N��\��
                    mIsActiveSpiky = true;
                    mBoxCollider2D.enabled = true; // �R���C�_�[��L����
                }
            }
            else
            {
                mSpiky.position = Vector3.Lerp(mSpiky.position, mActiveSpokyPos, Time.deltaTime * mSpeed);
            }
        }
    }
}
