using UnityEngine;

namespace MyAssets
{
    public enum CharacterState
    {
        Idle,
        Run,
        Jump,
        Fall,
        Attack
    }
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerMovementer : MonoBehaviour
    {

        private PlayerInput         mPlayerInput;

        private Rigidbody2D         mRigidbody2D;

        private CapsuleCollider2D   mCapsuleCollider2D;

        [SerializeField]
        private float mMoveSpeed = 5f;
        [SerializeField]
        private float mJumpForce = 10f;

        private bool mIsGrounded = false;
        public bool IsGrounded => mIsGrounded;

        private void Awake()
        {
            mPlayerInput = GetComponent<PlayerInput>();
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }


        private void Update()
        {
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
        }

        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            Vector2 moveValue = mPlayerInput.MoveValue;
            Vector2 moveDirection = new Vector2(moveValue.x, 0f).normalized;
            float speedX = mMoveSpeed * Time.fixedDeltaTime;
            mRigidbody2D.linearVelocity = new Vector2(moveDirection.x * speedX, mRigidbody2D.linearVelocity.y);
        }

        private void Jump()
        {
            if (mPlayerInput.MoveValue.y > 0&&mIsGrounded)
            {
                mRigidbody2D.AddForce(Vector2.up * mJumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
