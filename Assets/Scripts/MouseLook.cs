using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private Transform playerBody;
    public bool canLooking;
    private float verticalRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        canLooking = true;
    }

    private void Update()
    {
        if (canLooking)
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            verticalRotation -= mouseY;
            verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

            // Obrót kamery góra/dół
            transform.localRotation =
                Quaternion.Euler(verticalRotation, 0f, 0f);

            // Obrót całego gracza lewo/prawo
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}