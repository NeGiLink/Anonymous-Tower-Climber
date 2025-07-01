using System.Collections.Generic;
using UnityEngine;

namespace MyAssets
{
    // プレイヤーキャラクターのアニメーションを制御するクラス
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerMovementer))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private PlayerInput             mPlayerInput;

        public PlayerInput              PlayerInput => mPlayerInput;

        private PlayerMovementer        mPlayerMovementer;

        public PlayerMovementer         PlayerMovementer => mPlayerMovementer;

        private Animator                mAnimator;

        public Animator                 Animator => mAnimator;

        private PlayerSEManager         mPlayerSEManager;

        public PlayerSEManager          PlayerSEManager => mPlayerSEManager;

        private string                  mMoveName = "Move";
        public string                   MoveName => mMoveName;

        private string                  mJumpName = "Jump";

        public string                   JumpName => mJumpName;

        private string                  mAttackName = "Attack";

        public string                   AttackName => mAttackName;

        [SerializeField]
        private AnimationStateType      mInitState;
        [SerializeField]
        private AnimationStateType      mCurrentState;

        public AnimationStateType       CurrentState => mCurrentState;

        public void SetCurrentState(AnimationStateType state)
        {
            mCurrentState = state;
        }

        private IdleState               mIdleState;

        private RunState                mRunState;

        private JumpIdleState           mJumpIdleState;

        private JumpState               mJumpState;

        private DeathState              mDeathState;

        private AnimationState          mAnimationState;

        private List<AnimationState>    mAnimationStates = new List<AnimationState>();

        private void Awake()
        {
            mPlayerInput = GetComponent<PlayerInput>();
            mPlayerMovementer = GetComponent<PlayerMovementer>();
            mAnimator = GetComponent<Animator>();
            mPlayerSEManager = GetComponent<PlayerSEManager>();
        }

        void Start()
        {
            // Initialize individual states
            mIdleState = new IdleState();
            mRunState = new RunState();
            mJumpIdleState = new JumpIdleState();
            mJumpState = new JumpState();
            mDeathState = new DeathState();

            // Correctly initialize the array of AnimationState objects
            AnimationState[] states = new AnimationState[]
            {
                mIdleState,
                mRunState,
                mJumpIdleState,
                mJumpState,
                mDeathState
            };

            for(int i = 0; i < states.Length; i++)
            {
                states[i].SetUp(this);
            }

            // Add states to the list
            mAnimationStates.AddRange(states);

            // Set the initial animation state
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
        private void Update()
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
        eAttack,
        eDeath
    }

    // AnimationStateクラスは、プレイヤーのアニメーション状態を管理するための基底クラスです。
    public class AnimationState
    {
        protected PlayerAnimationController mAnimationController;


        public virtual void SetUp(PlayerAnimationController animationController)
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

    // 各アニメーション状態を表すクラス
    
    public class IdleState : AnimationState
    {
        private PlayerDamageController mDamagerController;

        public override void SetUp(PlayerAnimationController animationController)
        {
            base.SetUp(animationController);
            mDamagerController = animationController.gameObject.GetComponent<PlayerDamageController>();
        }

        public override AnimationStateType IsTransitioning()
        {
            if(mDamagerController.Death)
            {
                return AnimationStateType.eDeath;
            }
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
        private PlayerDamageController mDamagerController;

        public override void SetUp(PlayerAnimationController animationController)
        {
            base.SetUp(animationController);
            mDamagerController = animationController.gameObject.GetComponent<PlayerDamageController>();
        }

        public override AnimationStateType IsTransitioning()
        {
            if (mDamagerController.Death)
            {
                return AnimationStateType.eDeath;
            }
            if (mAnimationController.PlayerInput.MoveValue.x == 0)
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
    }

    public class JumpIdleState : AnimationState
    {
        private PlayerDamageController mDamagerController;

        public override void SetUp(PlayerAnimationController animationController)
        {
            base.SetUp(animationController);
            mDamagerController = animationController.gameObject.GetComponent<PlayerDamageController>();
        }

        public override AnimationStateType IsTransitioning()
        {
            if (mDamagerController.Death)
            {
                return AnimationStateType.eDeath;
            }
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

        public override void Exit()
        {
            mAnimationController.PlayerMovementer.SetMoveStoping(false);
            mAnimationController.PlayerSEManager.OnPlay((int)PlayerSEManager.SEList_Player.eJump);
        }
    }

    public class JumpState : AnimationState
    {
        private PlayerDamageController mDamagerController;

        public override void SetUp(PlayerAnimationController animationController)
        {
            base.SetUp(animationController);
            mDamagerController = animationController.gameObject.GetComponent<PlayerDamageController>();
        }

        public override AnimationStateType IsTransitioning()
        {
            if (mDamagerController.Death)
            {
                return AnimationStateType.eDeath;
            }
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
    }

    public class DeathState : AnimationState
    {
        private PlayerDamageController mDamagerController;

        public override void SetUp(PlayerAnimationController animationController)
        {
            base.SetUp(animationController);
            mDamagerController = animationController.gameObject.GetComponent<PlayerDamageController>();
        }
        public override AnimationStateType IsTransitioning()
        {
            return AnimationStateType.eNone;
        }

        public override void Start()
        {
            mAnimationController.PlayerSEManager.OnPlay((int)PlayerSEManager.SEList_Player.eDamage);
        }
    }
}
