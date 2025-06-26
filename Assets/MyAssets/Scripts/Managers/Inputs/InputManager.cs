using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyAssets
{
    // É{É^ÉìÇÃèÛë‘
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
        eSprint
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
        }

        public static void Shutdown()
        {
            mButtonActions.Clear();
            // Destructor logic if needed
            // Disable the Input System
            mInputAction.Disable();
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
