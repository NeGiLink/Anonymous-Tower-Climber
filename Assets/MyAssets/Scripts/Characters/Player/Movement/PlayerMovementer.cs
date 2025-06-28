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


        private bool mIsMoveStoping;

        public void SetMoveStoping(bool isStoping)
        {
            mIsMoveStoping = isStoping;
        }

        private void Awake()
        {
            mPlayerInput = GetComponent<PlayerInput>();
            mRigidbody2D = GetComponent<Rigidbody2D>();
            mCapsuleCollider2D = GetComponent<CapsuleCollider2D>();
        }


        private void Update()
        {

        }

        private void FixedUpdate()
        {
            Move();
            Jump();
        }

        private void Move()
        {
            if(mIsMoveStoping)
            {
                mRigidbody2D.linearVelocity = new Vector2(0f, mRigidbody2D.linearVelocity.y);
                return;
            }
            Vector2 moveValue = mPlayerInput.MoveValue;
            Vector2 moveDirection = new Vector2(moveValue.x, 0f).normalized;
            float speedX = mMoveSpeed * Time.deltaTime;
            mRigidbody2D.linearVelocity = new Vector2(moveDirection.x * speedX, mRigidbody2D.linearVelocity.y);
        }

        private void Jump()
        {
            if (mPlayerInput.Jump && mPlayerInput.IsGrounded)
            {
                Vector3 force = mRigidbody2D.linearVelocity;
                Vector3 addForce = Vector2.up * (mJumpForce * (mPlayerInput.JumpValue + 1.0f));
                if(force.y > 0)
                {
                    // Šù‚Éã•ûŒü‚É—Í‚ª‰Á‚í‚Á‚Ä‚¢‚éê‡AƒWƒƒƒ“ƒv‚µ‚È‚¢
                    return;
                }
                mRigidbody2D.AddForce(Vector2.up * (mJumpForce * (mPlayerInput.JumpValue + 1.0f)), ForceMode2D.Impulse);
            }
        }
    }
}
