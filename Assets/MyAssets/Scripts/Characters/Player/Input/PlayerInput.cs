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
            //�W�����v����
            if(InputManager.GetKey(KeyCode.eJump))
            {
                mJumpIdle = true;
            }
            else if(InputManager.GetKeyUp(KeyCode.eJump))
            {
                mJump = true;
                mJumpIdle = false;
            }

            //�n�ʂɐڒn���Ă��邩�ǂ����̔���
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
            //�ڒn���Ă����Ԃ��痣�ꂽ�ꍇ�A�W�����v���͂����Z�b�g
            if (!mIsPastGrounded && mIsGrounded)
            {
                mJump = false;
                mJumpValue = 0f;
            }
            // �W�����v���͂�����ꍇ�A�W�����v�l�𑝉�������
            if (mMoveValue.y > 0 && mIsGrounded)
            {
                mJumpValue += Time.deltaTime;
                if (mJumpValue > 0.3f)
                {
                    mJumpValue = 0.3f;
                }
            }

            // �ڒn��Ԃ��X�V
            mIsPastGrounded = mIsGrounded;
        }
    }
}
