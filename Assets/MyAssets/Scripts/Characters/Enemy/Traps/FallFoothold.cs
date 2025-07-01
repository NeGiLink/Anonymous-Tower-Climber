using UnityEngine;

namespace MyAssets
{
    // 足場が落ちるトラップのクラス
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
                //画面の下に落ちたら削除
                if (mViewportPos.y < 0.0f)
                {
                    // 画面外に出たら削除
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
                // PlayerがRayの先にいる場合、足場を落とす
                mIsFall = true;
                mRigidbody2D.gravityScale = mFallGravityScale;
            }
            Debug.DrawRay(ray2D.origin, ray2D.direction * mRayLength, Color.red);
        }
    }
}
