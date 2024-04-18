using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDos.Controls
{
    public class ControlsHandler : MonoBehaviour
    {
        public Controls Controls { get; private set; }
        public Vector2 MoveInputDirection { get; private set; }
        public bool JumpInputTriggered { get; private set; }
        public bool ShootInputTriggered {  get; private set; }

        private void Awake()
        {
            Controls = new Controls();
        }

        private void OnEnable()
        {
            Controls.Enable();
        }

        private void OnDisable()
        {
            Controls.Disable();
        }

        public void OnMoveInput(InputAction.CallbackContext ctx)
        {
            MoveInputDirection = ctx.ReadValue<Vector2>();
        }

        public void OnJumpInput(InputAction.CallbackContext ctx)
        {
            JumpInputTriggered = ctx.ReadValueAsButton();
        }

        public void OnShootInput(InputAction.CallbackContext ctx)
        {
            ShootInputTriggered = ctx.ReadValueAsButton();
        }
    }
}
