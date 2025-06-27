using UnityEngine;

namespace MyAssets
{
    public class FallFoothold : DynamicGameObject
    {

        [SerializeField]
        private bool mIsFall;

        private Rigidbody2D mRigidbody2D;

        private BoxCollider2D mBoxCollider2D;
        [SerializeField]
        private float mFallGravityScale;
        [SerializeField]
        private float mRayLength;

        [SerializeField]
        private float mRayPosX;

        private void Awake()
        {
            mRigidbody2D = GetComponentInChildren<Rigidbody2D>();
            mBoxCollider2D = GetComponentInChildren<BoxCollider2D>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
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
                //âÊñ ÇÃâ∫Ç…óéÇøÇΩÇÁçÌèú
                if (mViewportPos.y < 0.0f)
                {
                    // âÊñ äOÇ…èoÇΩÇÁçÌèú
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
                // PlayerÇ™RayÇÃêÊÇ…Ç¢ÇÈèÍçáÅAë´èÍÇóéÇ∆Ç∑
                mIsFall = true;
                mRigidbody2D.gravityScale = mFallGravityScale;
            }
            Debug.DrawRay(ray2D.origin, ray2D.direction * mRayLength, Color.red);
        }
    }
}
