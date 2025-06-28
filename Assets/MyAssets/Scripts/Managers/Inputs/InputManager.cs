using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyAssets
{
    // �{�^���̏��
    public enum ButtonState
    {
        eNone,
        ePressed,
        eReleased,
        eHeld
    };

    public enum KeyCode
    {
        eNone = -1,
        eMove,
        eLook,
        eAttack,
        eInteract,
        eCrouch,
        eJump,
        ePrevious,
        eNext,
        eSprint,
        eUpSelect,
        eDownSelect,
        eLeftSelect,
        eRightSelect,
        eDecide,
        eESC
    };

    public class InputManager
    {
        private static InputSystem_Actions mInputAction;


        private static List<InputAction> mButtonActions = new List<InputAction>();


        public InputManager()
        {
            // Constructor logic if needed
            // Initialize the Input System
            mInputAction = new InputSystem_Actions();
            mInputAction.Enable();

            mButtonActions.Add(mInputAction.Player.Move);
            mButtonActions.Add(mInputAction.Player.Look);
            mButtonActions.Add(mInputAction.Player.Attack);
            mButtonActions.Add(mInputAction.Player.Interact);
            mButtonActions.Add(mInputAction.Player.Crouch);
            mButtonActions.Add(mInputAction.Player.Jump);
            mButtonActions.Add(mInputAction.Player.Previous);
            mButtonActions.Add(mInputAction.Player.Next);
            mButtonActions.Add(mInputAction.Player.Sprint);
            mButtonActions.Add(mInputAction.UI.UpSelect);
            mButtonActions.Add(mInputAction.UI.DownSelect);
            mButtonActions.Add(mInputAction.UI.LeftSelect);
            mButtonActions.Add(mInputAction.UI.RightSelect);
            mButtonActions.Add(mInputAction.UI.Decide);
            mButtonActions.Add(mInputAction.UI.Option);
        }

        ~InputManager()
        {
            mButtonActions.Clear();
            // Destructor logic if needed
            // Disable the Input System
            mInputAction.Disable();
        }

        public static void Initialize()
        {
            if(mInputAction != null)
            {
                return; // Already initialized
            }
            // Constructor logic if needed
            // Initialize the Input System
            mInputAction = new InputSystem_Actions();
            mInputAction.Enable();

            mButtonActions.Add(mInputAction.Player.Move);
            mButtonActions.Add(mInputAction.Player.Look);
            mButtonActions.Add(mInputAction.Player.Attack);
            mButtonActions.Add(mInputAction.Player.Interact);
            mButtonActions.Add(mInputAction.Player.Crouch);
            mButtonActions.Add(mInputAction.Player.Jump);
            mButtonActions.Add(mInputAction.Player.Previous);
            mButtonActions.Add(mInputAction.Player.Next);
            mButtonActions.Add(mInputAction.Player.Sprint);
            mButtonActions.Add(mInputAction.UI.UpSelect);
            mButtonActions.Add(mInputAction.UI.DownSelect);
            mButtonActions.Add(mInputAction.UI.LeftSelect);
            mButtonActions.Add(mInputAction.UI.RightSelect);
            mButtonActions.Add(mInputAction.UI.Decide);
            mButtonActions.Add(mInputAction.UI.Option);
        }

        public static void Shutdown()
        {
            mButtonActions.Clear();
            // Destructor logic if needed
            // Disable the Input System
            mInputAction.Disable();
        }

        public static void SetLockedMouseMode()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        public static void SetNoneMouseMode()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        public static bool GetKey(KeyCode code)
        {
            return mButtonActions[(int)code].IsPressed();
        }

        public static bool GetKeyDown(KeyCode code)
        {
            return mButtonActions[(int)code].WasPressedThisFrame();
        }

        public static bool GetKeyUp(KeyCode code)
        {
            return mButtonActions[(int)code].WasReleasedThisFrame();
        }

        public static Vector2 GetKeyValue(KeyCode code)
        {
            return mButtonActions[(int)code].ReadValue<Vector2>();
        }

    }

}
