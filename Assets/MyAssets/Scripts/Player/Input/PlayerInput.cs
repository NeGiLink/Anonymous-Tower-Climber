using UnityEngine;

namespace MyAssets
{
    [RequireComponent(typeof(PlayerMovementer))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField]
        private Vector2 mMoveValue;
        public Vector2  MoveValue => mMoveValue;
        [SerializeField]
        private bool    mJump;
        public bool     Jump => mJump;

        // Update is called once per frame
        private void Update()
        {
            mMoveValue = InputManager.GetKeyValue(KeyCode.eMove);

            mJump = false;
            if(InputManager.GetKeyDown(KeyCode.eJump))
            {
                mJump = true;
            }
        }
    }
}
