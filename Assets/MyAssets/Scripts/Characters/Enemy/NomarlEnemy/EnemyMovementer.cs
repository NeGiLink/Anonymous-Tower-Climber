using UnityEngine;

namespace MyAssets
{
    // ìGÉLÉÉÉâÉNÉ^Å[ÇÃà⁄ìÆÇä«óùÇ∑ÇÈÉNÉâÉX
    public class EnemyMovementer : DynamicGameObject
    {
        [SerializeField]
        private bool                mIsCliffStop;

        [SerializeField]
        private float               mMoveSpeed;

        [SerializeField]
        private float               mMoveDirection;

        private Rigidbody2D         mRigidbody2D;

        private CapsuleCollider2D   mCapsuleCollider2D;
        private void Awake()
        {
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public override void Start()
        {
            mMoveDirection = 1f;
        }

        // Update is called once per frame
        public override void Update()
        {
            base.Update();
            if (IsTopOutViewport()||IsBottomOutViewport())
            {
                return;
            }
            ReverseCheck();
        }

        private void FixedUpdate()
        {
            if (IsOutViewport())
            {
                return;
            }
            Move();
        }

        private void ReverseCheck()
        {
            //ï«Ç…Ç‘Ç¬Ç©Ç¡ÇΩÇÁîΩì]
            Vector3 origin = new Vector3(transform.position.x + ((mCapsuleCollider2D.size.x / 2f) * mMoveDirection),
                              transform.position.y, transform.position.z);
            Ray2D ray = new Ray2D(origin, transform.right * mMoveDirection);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 0.25f, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                Reverse();
            }
            Debug.DrawRay(ray.origin, ray.direction * 0.1f, Color.red);

            //äRÇ…Ç‘Ç¬Ç©Ç¡ÇΩÇÁîΩì]
            if (mIsCliffStop)
            {
                origin = new Vector3(transform.position.x + ((mCapsuleCollider2D.size.x / 2f) * mMoveDirection),
                                     transform.position.y, transform.position.z);
                ray = new Ray2D(origin, Vector2.down);
                hit = Physics2D.Raycast(ray.origin, ray.direction, mCapsuleCollider2D.size.y / 2 + 0.1f, LayerMask.GetMask("Ground"));
                if (hit.collider == null)
                {
                    Reverse();
                }
                Debug.DrawRay(ray.origin, ray.direction * (mCapsuleCollider2D.size.x / 2 + 0.1f), Color.blue);
            }
        }

        private void Reverse()
        {
            mMoveDirection *= -1f;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }

        private void Move()
        {
            float speedX = mMoveSpeed * Time.deltaTime;
            mRigidbody2D.linearVelocity = new Vector2(mMoveDirection * speedX, mRigidbody2D.linearVelocity.y);
        }
    }
}
