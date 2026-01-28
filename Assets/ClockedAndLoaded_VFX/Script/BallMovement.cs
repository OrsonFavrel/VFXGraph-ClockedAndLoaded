using UnityEngine;
using UnityEngine.InputSystem;

namespace ClockedAndLoaded
{
    public class BallMovement : MonoBehaviour
    {
        [SerializeField] private  Rigidbody rbdSphere;
        [SerializeField] private float forceStrength = 5.0f;
        [SerializeField] private float dragForce = 1f;
        private Vector3 _moveDirection;
        
        public void OnMoveAction(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                var moveInput = context.ReadValue<Vector2>();
                _moveDirection = new Vector3(moveInput.x, 0, moveInput.y) * -1;
                rbdSphere.AddForce(_moveDirection * forceStrength, ForceMode.VelocityChange);
            }
            else if (context.canceled)
            {
                _moveDirection = Vector3.zero;
            }
        }
        
        void Update()
        {
            rbdSphere.linearVelocity = Vector3.Slerp(rbdSphere.linearVelocity, Vector3.zero, Time.deltaTime * dragForce);
        }
    }
}
