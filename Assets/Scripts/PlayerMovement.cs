using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -20f;
    [SerializeField] private CharacterController player;

    private float verticalVelocity;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 horizontalMovement =
            transform.right * horizontal +
            transform.forward * vertical;

        horizontalMovement =
            horizontalMovement.normalized * movementSpeed;

        if (player.isGrounded && verticalVelocity < 0f)
        {
            verticalVelocity = -2f;
        }

        if (Input.GetButtonDown("Jump") && player.isGrounded)
        {
            verticalVelocity =
                Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        verticalVelocity += gravity * Time.deltaTime;

        Vector3 movement =
            horizontalMovement +
            Vector3.up * verticalVelocity;

        player.Move(movement * Time.deltaTime);
    }
}