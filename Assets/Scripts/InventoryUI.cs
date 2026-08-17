using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private bool isInventoryOpen = false;
    [SerializeField] private MouseLook mouseLook;
    [SerializeField] private PlayerMovement playerMovement;
    private void Awake()
    {
        inventoryPanel.SetActive(false);
        isInventoryOpen = false;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I) && !isInventoryOpen)
        {
            inventoryPanel.SetActive(true);
            isInventoryOpen = true;
            mouseLook.canLooking = false;
            playerMovement.canMove = false;
        }
        else if((Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape)) && isInventoryOpen)
        {
            inventoryPanel.SetActive(false);
            isInventoryOpen = false;
            mouseLook.canLooking = true;
            playerMovement.canMove = true;
        }
    }
}
