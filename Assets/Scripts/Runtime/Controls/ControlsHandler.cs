using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDos.Controls
{
    public class ControlsHandler : MonoBehaviour
    {
        private Controls _controls;

        public Vector2 MoveInputDirection { get; private set; }
        public bool JumpInputTriggered { get; private set; }
        public bool ShootInpuTriggered {  get; private set; }

        private void Awake()
        {
            _controls = new Controls();
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void OnDisable()
        {
            _controls.Disable();
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
            ShootInpuTriggered = ctx.ReadValueAsButton();
        }
    }
}
