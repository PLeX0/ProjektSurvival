using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float interactionDistance = 3f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);


        if(Physics.Raycast(ray, out RaycastHit hit, interactionDistance))
        {
            Debug.Log(hit.collider.gameObject.name);
        }
    }

}
