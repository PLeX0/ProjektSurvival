using System;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private static int slotCount = 25;
    [SerializeField] private int[] slot = new int[slotCount];
    [SerializeField] private bool isInventoryFull;

    private void Awake()
    {
        isInventoryFull = false;
        for(int i = 0; i < slotCount; i++)
        {
            slot[i] = -1;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            for(int i = 0; i < slotCount; i++)
            {
                Debug.Log(slot[i]);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryAddItemToInventory(67);
        }
    }

    public void TryAddItemToInventory(int id)
    {
        if(!isInventoryFull)
        {
            for(int i = 0; i < slotCount; i++)
            {
                if (slot[i] == -1)
                {
                    slot[i] = id;
                    break;
                }
            }
        }
    }
}
