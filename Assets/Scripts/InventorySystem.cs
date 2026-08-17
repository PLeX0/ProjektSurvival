using System;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    private const int SlotCount = 25;

   
   [SerializeField] private InventorySlot[] slots = new InventorySlot[SlotCount];
    
   [SerializeField] private ItemDatabase itemDatabase;


    public event Action<int> OnSlotChanged;

    public int Count => slots.Length;

    public bool IsInventoryFull
    {
        get
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].IsEmpty)
                {
                    return false;
                }
            }

            return true;
        }
    }

    private void Awake()
    {
        if (slots == null || slots.Length != SlotCount)
        {
            slots = new InventorySlot[SlotCount];
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = new InventorySlot();
            }
        }
    }

    private void Update()
    {
        // Tests
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PrintInventory();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryAddItemToInventory(1, 20);
        }
    }

    public int AddItemToInventory(int itemId, int amount = 1)
    {
        if (itemDatabase == null)
        {
            Debug.LogError("ItemDatabase nie zostało przypisane.");
            return 0;
        }

        if (amount <= 0)
        {
            return 0;
        }

        ItemData itemData = itemDatabase.GetItemById(itemId);

        if (itemData == null)
        {
            return 0;
        }

        int maxStackSize = itemData.MaxStackSize;
        int remainingAmount = amount;


        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].ContainsItem(itemId))
            {
                continue;
            }

            if (slots[i].Amount >= maxStackSize)
            {
                continue;
            }

            int freeSpace = maxStackSize - slots[i].Amount;
            int amountToAdd = Mathf.Min(freeSpace, remainingAmount);

            slots[i].AddAmount(amountToAdd);
            remainingAmount -= amountToAdd;

            OnSlotChanged?.Invoke(i);

            if (remainingAmount == 0)
            {
                break;
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (remainingAmount == 0)
            {
                break;
            }

            if (!slots[i].IsEmpty)
            {
                continue;
            }

            int amountToAdd = Mathf.Min(
                maxStackSize,
                remainingAmount
            );

            slots[i].SetItem(itemId, amountToAdd);
            remainingAmount -= amountToAdd;

            OnSlotChanged?.Invoke(i);
        }

        int addedAmount = amount - remainingAmount;

        return addedAmount;
    }

    public bool TryAddItemToInventory(int itemId, int amount = 1)
    {
        if (itemDatabase == null)
        {
            Debug.LogError("ItemDatabase nie zostało przypisane.");
            return false;
        }

        if (amount <= 0)
        {
            return false;
        }

        ItemData itemData = itemDatabase.GetItemById(itemId);

        if (itemData == null)
        {
            return false;
        }

        int maxStackSize = itemData.MaxStackSize;


        int remainingAmount = amount;

        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].ContainsItem(itemId))
            {
                continue;
            }

            if (slots[i].Amount >= maxStackSize)
            {
                continue;
            }

            int freeSpace = maxStackSize - slots[i].Amount;
            int amountToAdd = Mathf.Min(freeSpace, remainingAmount);

            slots[i].AddAmount(amountToAdd);
            remainingAmount -= amountToAdd;

            OnSlotChanged?.Invoke(i);

            if (remainingAmount == 0)
            {
                return true;
            }
        }

        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].IsEmpty)
            {
                continue;
            }

            int amountToAdd = Mathf.Min(
                maxStackSize,
                remainingAmount
            );

            slots[i].SetItem(itemId, amountToAdd);
            remainingAmount -= amountToAdd;

            OnSlotChanged?.Invoke(i);

            if (remainingAmount == 0)
            {
                return true;
            }
        }

        return false;
    }

    public InventorySlot GetSlot(int slotIndex)
    {
        return slots[slotIndex];
    }

    private void PrintInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            InventorySlot currentSlot = slots[i];

            Debug.Log(
                $"Slot {i}: ID = {currentSlot.ItemId}, " +
                $"ilość = {currentSlot.Amount}"
            );
        }
    }

    public ItemData GetItemData(int itemId)
    {
        if (itemDatabase == null)
        {
            Debug.LogError("ItemDatabase nie zostało przypisane.");
            return null;
        }

        return itemDatabase.GetItemById(itemId);
    }
}