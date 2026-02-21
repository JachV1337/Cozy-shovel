using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Slider staminaSlider;
    [SerializeField] TakeSnow takeSnow;

    private float currentMovementSpeed;
    private float walkSpeed = 5f;
    private float sprintSpeed = 8f;
    private float maxStamina = 100f;
    private float staminaTakeNum = 5f;
    private float currentStamina;
    private float previousStamina;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private bool canSprint;
    private float staminaRegenRate = 10f;     // ile staminy na sekundę wraca
    private float sprintBlockThreshold = 20f; // ile trzeba mieć, żeby znów sprintować
    private bool sprintBlocked;               // czy sprint jest zablokowany

    void Start()
    {
        takeSnow = GetComponent<TakeSnow>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentMovementSpeed = walkSpeed;
        animator = GetComponent<Animator>();
        currentStamina = maxStamina;
    }

    void Update()
    {
        bool isMoving = moveInput.sqrMagnitude > 0.01f;
        bool isSprinting = canSprint && !sprintBlocked && currentStamina > 0 && isMoving;

        if ((isMoving || isSprinting) && takeSnow.isTakingSnow)
        {
            takeSnow.CancelTakingSnow();
        }
        // ================= STAMINA =================

        if (isSprinting)
        {
            currentStamina -= staminaTakeNum * Time.deltaTime;
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);

            // Regeneracja tylko gdy NIE sprintujesz
            if (currentStamina < maxStamina)
            {
                currentStamina += staminaRegenRate * Time.deltaTime;
            }
        }

        // Clamp żeby nie wyjść poza zakres
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        // Jeśli stamina spadnie do 0 → blokujemy sprint
        if (currentStamina <= 0)
        {
            sprintBlocked = true;
            canSprint = false;
        }

        // Odblokowanie sprintu dopiero gdy stamina >= 20
        if (sprintBlocked && currentStamina >= sprintBlockThreshold)
        {
            sprintBlocked = false;
        }

        // ================= SPEED =================

        currentMovementSpeed = isSprinting ? sprintSpeed : walkSpeed;

        // ================= ANIMACJE =================

        animator.SetBool("isWalking", isMoving && !isSprinting);

        if (isMoving)
        {
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);

            if (moveInput.x > 0)
                spriteRenderer.flipX = false;
            else if (moveInput.x < 0)
                spriteRenderer.flipX = true;
        }

        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
        if (currentStamina != previousStamina)
        {
            staminaSlider.value = currentStamina;
            previousStamina = currentStamina;
        }
    }


    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * currentMovementSpeed;
    }


    public void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed && !sprintBlocked)
        {
            canSprint = true;
        }

        if (context.canceled)
        {
            canSprint = false;
        }
    }

}
