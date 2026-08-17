using System;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    [SerializeField] private int itemId = -1;
    [SerializeField] private int amount;

    public int ItemId => itemId;
    public int Amount => amount;
    public bool IsEmpty => itemId == -1;

    public bool ContainsItem(int id)
    {
        return !IsEmpty && itemId == id;
    }

    public void SetItem(int id, int newAmount = 1)
    {
        if (id < 0 || newAmount <= 0)
        {
            Clear();
            return;
        }

        itemId = id;
        amount = newAmount;
    }

    public void AddAmount(int value)
    {
        if(value > 0)
        {
            amount += value;
        }
    }

    public void RemoveAmount(int value)
    {
        if (value <= 0)
        {
            return;
        }

        amount -= value;

        if (amount <= 0)
        {
            Clear();
        }
    }

    public void Clear()
    {
        itemId = -1;
        amount = 0;
    }
}