using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Components References")] 
        [SerializeField] private Rigidbody2D rb;

        [Header("Jump Settings")] 
        [SerializeField] private float jumpForce;

        public void OnJump(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Jump();
            }
        }

        private void Jump()
        {
            // rb.linearVelocity = Vector2.up * jumpForce;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
