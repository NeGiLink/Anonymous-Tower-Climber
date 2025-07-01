using UnityEngine;

namespace MyAssets
{
    // ���ꂪ������g���b�v�̃N���X
    public class FallFoothold : DynamicGameObject
    {

        [SerializeField]
        private bool        mIsFall;

        private Rigidbody2D mRigidbody2D;


        [SerializeField]
        private float       mFallGravityScale;
        [SerializeField]
        private float       mRayLength;

        [SerializeField]
        private float       mRayPosX;

        private void Awake()
        {
            mRigidbody2D = GetComponentInChildren<Rigidbody2D>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public override void Start()
        {
            mRigidbody2D.gravityScale = 0f;
            mIsFall = false;
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
            if (!mIsFall)
            {
                FallCheck();
            }
            else
            {
                //��ʂ̉��ɗ�������폜
                if (mViewportPos.y < 0.0f)
                {
                    // ��ʊO�ɏo����폜
                    Destroy(gameObject);
                }
            }
        }

        private void FallCheck()
        {
            Ray2D ray2D = new Ray2D(transform.position + new Vector3(mRayPosX, 0.0f, 0.0f), Vector2.down);
            RaycastHit2D hit = Physics2D.Raycast(ray2D.origin, ray2D.direction, mRayLength, LayerMask.GetMask("DynamicObject"));
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                // Player��Ray�̐�ɂ���ꍇ�A����𗎂Ƃ�
                mIsFall = true;
                mRigidbody2D.gravityScale = mFallGravityScale;
            }
            Debug.DrawRay(ray2D.origin, ray2D.direction * mRayLength, Color.red);
        }
    }
}
