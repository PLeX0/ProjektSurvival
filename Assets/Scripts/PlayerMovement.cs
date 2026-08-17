using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -20f;
    public bool canMove;

    [Header("Stamina")]
    [SerializeField] private float sprintStaminaDrainPerSecond = 20f;
    [SerializeField] private float staminaRegenerationPerSecond = 10f;
    [SerializeField] private float staminaRegenerationDelay = 2f;
    [SerializeField] private float jumpStaminaCost = 10f;


    [Header("References")]
    [SerializeField] private CharacterController player;
    [SerializeField] private PlayerStats playerStats;

    private float verticalVelocity;
    private float lastStaminaUseTime;


    private void Awake()
    {

        if (player == null)
        {
            player = GetComponent<CharacterController>();
        }

        if (playerStats == null)
        {
            playerStats = GetComponent<PlayerStats>();
        }

        canMove = true;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector3 movementDirection = Vector3.zero;
        if (canMove)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            movementDirection =
                transform.right * horizontal +
                transform.forward * vertical;

            movementDirection = movementDirection.normalized;
        }
        bool isMoving = movementDirection.sqrMagnitude > 0f;

        bool isSprinting =
            Input.GetKey(KeyCode.LeftShift) &&
            isMoving &&
            playerStats.stamina > 0f;

        bool staminaUsedThisFrame = false;

        float currentSpeed = playerStats.movementSpeed;

        if (isSprinting)
        {
            
            currentSpeed += playerStats.sprintSpeed;

            playerStats.stamina -=
                sprintStaminaDrainPerSecond * Time.deltaTime;

            staminaUsedThisFrame = true;
        }


        if (player.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        if (player.isGrounded && Input.GetButtonDown("Jump") && playerStats.stamina >= jumpStaminaCost)
        {
           

            playerStats.stamina -= jumpStaminaCost;

            verticalVelocity =
                Mathf.Sqrt(jumpHeight * -2f * gravity);

            staminaUsedThisFrame = true;
        }


        if (staminaUsedThisFrame)
        {
            lastStaminaUseTime = Time.time;
        }

        else if (Time.time - lastStaminaUseTime >= staminaRegenerationDelay)
        {

            playerStats.stamina +=
                staminaRegenerationPerSecond * Time.deltaTime;
            
        }

        playerStats.stamina = Mathf.Clamp(
            playerStats.stamina,
            0f,
            playerStats.maxStamina
        );

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 finalMovement =
            movementDirection * currentSpeed +
            Vector3.up * verticalVelocity;

        player.Move(finalMovement * Time.deltaTime);
       
    }
}