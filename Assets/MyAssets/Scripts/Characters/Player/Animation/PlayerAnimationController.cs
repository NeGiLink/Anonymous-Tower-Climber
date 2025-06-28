using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerMovementer))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private PlayerInput         mPlayerInput;

        public PlayerInput PlayerInput => mPlayerInput;

        private PlayerMovementer    mPlayerMovementer;

        public PlayerMovementer PlayerMovementer => mPlayerMovementer;

        private Animator            mAnimator;

        public Animator Animator => mAnimator;

        private string mMoveName = "Move";
        public string MoveName => mMoveName;

        private string mJumpName = "Jump";

        public string JumpName => mJumpName;

        private string mAttackName = "Attack";

        public string AttackName => mAttackName;

        [SerializeField]
        private AnimationStateType mInitState;
        [SerializeField]
        private AnimationStateType mCurrentState;

        public AnimationStateType CurrentState => mCurrentState;

        public void SetCurrentState(AnimationStateType state)
        {
            mCurrentState = state;
        }

        private IdleState mIdleState;

        private RunState mRunState;

        private JumpIdleState mJumpIdleState;

        private JumpState mJumpState;

        private AnimationState mAnimationState;

        private List<AnimationState> mAnimationStates = new List<AnimationState>();

        private void Awake()
        {
            mPlayerInput = GetComponent<PlayerInput>();
            mPlayerMovementer = GetComponent<PlayerMovementer>();
            mAnimator = GetComponent<Animator>();
        }
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            mIdleState = new IdleState();
            mRunState = new RunState();
            mJumpIdleState = new JumpIdleState();
            mJumpState = new JumpState();
            mIdleState.SetUp(this);
            mRunState.SetUp(this);
            mJumpIdleState.SetUp(this);
            mJumpState.SetUp(this);

            mAnimationStates.Add(mIdleState);
            mAnimationStates.Add(mRunState);
            mAnimationStates.Add(mJumpIdleState);
            mAnimationStates.Add(mJumpState);
            // 初期状態の設定
            TransAnimation(AnimationStateType.eIdle);
        }

        private void TransAnimation(AnimationStateType state)
        {
            mAnimationState?.Exit();
            mAnimationState = mAnimationStates[(int)state];
            mCurrentState = state;
            mAnimationState?.Start();
        }

        private void IsTransitioning()
        {
            AnimationStateType state = mAnimationState.IsTransitioning();
            if (state == AnimationStateType.eNone)
            {
                return;
            }
            TransAnimation(state);
        }

        // Update is called once per frame
        void Update()
        {
            //向き反転
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

            IsTransitioning();
            mAnimationState.Update();
        }
    }

    public enum AnimationStateType
    {
        eNone = -1,
        eIdle,
        eRun,
        eJumpIdle,
        eJump,
        eAttack
    }


    public class AnimationState
    {
        protected PlayerAnimationController mAnimationController;


        public void SetUp(PlayerAnimationController animationController)
        {
            mAnimationController = animationController;
        }

        public virtual AnimationStateType IsTransitioning()
        {
            return AnimationStateType.eNone;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {
            // アニメーションの状態を更新するロジック
        }

        public virtual void Exit()
        {

        }
    }


    public class IdleState : AnimationState
    {

        public override AnimationStateType IsTransitioning()
        {
            if(mAnimationController.PlayerInput.MoveValue.x != 0)
            {
                return AnimationStateType.eRun;
            }
            if (mAnimationController.PlayerInput.Jump)
            {
                return AnimationStateType.eJump;
            }
            if (mAnimationController.PlayerInput.JumpIdle)
            {
                return AnimationStateType.eJumpIdle;
            }
            return AnimationStateType.eNone;
        }

        public override void Start()
        {
            mAnimationController.Animator.SetInteger(mAnimationController.JumpName, -1);
            mAnimationController.Animator.SetInteger(mAnimationController.MoveName, 0);
        }
        public override void Update()
        {
        }

        public override void Exit()
        {
            
        }
    }

    public class RunState : AnimationState
    {

        public override AnimationStateType IsTransitioning()
        {
            if(mAnimationController.PlayerInput.MoveValue.x == 0)
            {
                return AnimationStateType.eIdle;
            }
            if (mAnimationController.PlayerInput.Jump)
            {
                return AnimationStateType.eJump;
            }
            if (mAnimationController.PlayerInput.JumpIdle)
            {
                return AnimationStateType.eJumpIdle;
            }
            return AnimationStateType.eNone;
        }

        public override void Start()
        {
            mAnimationController.Animator.SetInteger(mAnimationController.MoveName, 1);
        }
        public override void Update()
        {
        }

        public override void Exit()
        {
            
        }
    }

    public class JumpIdleState : AnimationState
    {

        public override AnimationStateType IsTransitioning()
        {
            if (mAnimationController.PlayerInput.Jump)
            {
                return AnimationStateType.eJump;
            }
            return AnimationStateType.eNone;
        }

        public override void Start()
        {
            mAnimationController.Animator.SetInteger(mAnimationController.MoveName, -1);
            mAnimationController.Animator.SetInteger(mAnimationController.JumpName, 0);
            mAnimationController.PlayerMovementer.SetMoveStoping(true);
        }
        public override void Update()
        {
        }

        public override void Exit()
        {
            mAnimationController.PlayerMovementer.SetMoveStoping(false);
        }
    }

    public class JumpState : AnimationState
    {

        public override AnimationStateType IsTransitioning()
        {
            if (mAnimationController.PlayerInput.IsGrounded)
            {
                return AnimationStateType.eIdle;
            }
            return AnimationStateType.eNone;
        }

        public override void Start()
        {
            mAnimationController.Animator.SetInteger(mAnimationController.MoveName, -1);
            mAnimationController.Animator.SetInteger(mAnimationController.JumpName, 1);
        }
        public override void Update()
        {
        }

        public override void Exit()
        {
            
        }
    }
}
