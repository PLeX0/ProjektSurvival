using UnityEngine;

[CreateAssetMenu(
    fileName = "ItemDatabase",
    menuName = "Inventory/Item Database"
)]
public class ItemDatabase : ScriptableObject
{
    [SerializeField]
    private ItemData[] items;

    public ItemData GetItemById(int id)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null && items[i].Id == id)
            {
                return items[i];
            }
        }

        Debug.LogWarning(
            $"Nie znaleziono przedmiotu o ID {id} w ItemDatabase."
        );

        return null;
    }
}