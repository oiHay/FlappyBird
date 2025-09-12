using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb2d;
    private PlayerInput playerInput;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (!CountDownTimer.movementLocked)
        {
            rb2d.gravityScale = 2;
            playerInput.enabled = true;
        }
        else
        {
            rb2d.gravityScale = 0;
            playerInput.enabled = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
