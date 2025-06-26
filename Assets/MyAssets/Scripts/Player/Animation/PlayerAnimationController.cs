using UnityEngine;

namespace MyAssets
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerMovementer))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private PlayerInput         mPlayerInput;

        private PlayerMovementer    mPlayerMovementer;

        private Animator            mAnimator;

        private string mMoveName = "Move";

        private string mJumpName = "Jump";

        private string mAttackName = "Attack";



        private void Awake()
        {
            mPlayerInput = GetComponent<PlayerInput>();
            mPlayerMovementer = GetComponent<PlayerMovementer>();
            mAnimator = GetComponent<Animator>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mAnimator.SetInteger(mMoveName, 0);
        }

        // Update is called once per frame
        void Update()
        {
            //Œü‚«”½“]
            Vector3 scale = transform.localScale;
            if (mPlayerInput.MoveValue.x > 0)
            {
                scale.x = 1;
            }
            else if (mPlayerInput.MoveValue.x < 0)
            {
                scale.x = -1;
            }
            transform.localScale = scale;

            mAnimator.SetInteger(mJumpName, -1);
            if(mPlayerInput.MoveValue.y > 0||!mPlayerMovementer.IsGrounded)
            {
                mAnimator.SetInteger(mJumpName, 0);
            }
            else
            {
                mAnimator.SetInteger(mMoveName, 0);
            }

        }
    }
}
