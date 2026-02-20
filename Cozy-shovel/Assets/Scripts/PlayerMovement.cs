using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private float currentMovementSpeed;
    private float walkSpeed = 6f;
    private float sprintSpeed = 11f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentMovementSpeed = walkSpeed;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //ruch
        rb.linearVelocity = moveInput * currentMovementSpeed;

        // Animacja chodzenia
        bool isWalking = moveInput.sqrMagnitude > 0.01f; // Threshold dla deadzone
        animator.SetBool("isWalking", isWalking);

        // Ostatni kierunek do Idle
        if (isWalking)
        {
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);

            // Flip X
            if (moveInput.x > 0)
                spriteRenderer.flipX = false;
            else if (moveInput.x < 0)
                spriteRenderer.flipX = true;
        }

        // Aktualny kierunek dla blend tree lub innych animacji
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
