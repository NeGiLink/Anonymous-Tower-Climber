using UnityEngine;
using UnityEngine.InputSystem;

namespace MyAssets
{
    [RequireComponent(typeof(PlayerMovementer))]
    public class PlayerInput : MonoBehaviour
    {
        private CapsuleCollider2D mCapsuleCollider2D;


        [SerializeField]
        private Vector2 mMoveValue;
        public Vector2  MoveValue => mMoveValue;

        [SerializeField]
        private bool mJumpIdle;

        public bool JumpIdle => mJumpIdle;

        [SerializeField]
        private bool    mJump;
        public bool     Jump => mJump;

        [SerializeField]
        private bool mIsGrounded;
        public bool IsGrounded => mIsGrounded;

        [SerializeField]
        private bool mIsPastGrounded;

        [SerializeField]
        private float mJumpValue;

        public float JumpValue => mJumpValue;

        private void Awake()
        {
            mCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }

        // Update is called once per frame
        private void Update()
        {
            mMoveValue = InputManager.GetKeyValue(KeyCode.eMove);
            //ジャンプ入力
            if(InputManager.GetKey(KeyCode.eJump))
            {
                mJumpIdle = true;
            }
            else if(InputManager.GetKeyUp(KeyCode.eJump))
            {
                mJump = true;
                mJumpIdle = false;
            }

            //地面に接地しているかどうかの判定
            Ray2D ray = new Ray2D(transform.position, Vector2.down);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, mCapsuleCollider2D.size.y / 2 + 0.1f, LayerMask.GetMask("Ground"));
            if (hit.collider != null)
            {
                Debug.DrawLine(ray.origin, hit.point, Color.green);
                mIsGrounded = true;
            }
            else
            {
                Debug.DrawRay(ray.origin, ray.direction * (mCapsuleCollider2D.size.y / 2 + 0.1f), Color.red);
                mIsGrounded = false;
            }
            //接地している状態から離れた場合、ジャンプ入力をリセット
            if (!mIsPastGrounded && mIsGrounded)
            {
                mJump = false;
                mJumpValue = 0f;
            }
            // ジャンプ入力がある場合、ジャンプ値を増加させる
            if (mMoveValue.y > 0 && mIsGrounded)
            {
                mJumpValue += Time.deltaTime;
                if (mJumpValue > 0.3f)
                {
                    mJumpValue = 0.3f;
                }
            }

            // 接地状態を更新
            mIsPastGrounded = mIsGrounded;
        }
    }
}
