using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item Data")]
public class ItemData : ScriptableObject
{
    [Header("Basic information")]

    [SerializeField]
    [Min(0)]
    private int id;

    [SerializeField]
    private string displayName;

    [SerializeField]
    [TextArea(3, 6)]
    private string description;

    [SerializeField]
    private ItemRarity itemRarity = ItemRarity.Common;

    [SerializeField]
    private Sprite icon;


    [Header("Inventory settings")]

    [SerializeField]
    private ItemType itemType;

    [SerializeField]
    [Min(1)]
    private int maxStackSize = 1;

    public int Id => id;
    public string DisplayName => displayName;
    public string Description => description;
    public ItemRarity ItemRarity => itemRarity;
    public Sprite Icon => icon;
    public ItemType ItemType => itemType;
    public int MaxStackSize => maxStackSize;
    public bool IsStackable => maxStackSize > 1;
}
