using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using JetBrains.Annotations;

[CreateAssetMenu]
public class InventorySO : ScriptableObject
{
    [SerializeField]
    private List<InventoryItem2> inventoryItems;
    [field: SerializeField]
    public int Size { get; private set; }=10;
    
    public void Initialize()
    {
        inventoryItems= new List<InventoryItem2>();
        for (int i=0; i<Size; i++)
        {
            inventoryItems.Add(InventoryItem2.GetEmptyItem());
        }
    }
    public void AddItem(ItemSO item)
    {
        for (int i=0; i<inventoryItems.Count;i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                
                inventoryItems[i] = new InventoryItem2
                {
                    item = item
                };
                break;
            }
        }
    }

    public Dictionary<int,InventoryItem2> GetCurrentInventoryState()
    {
        Dictionary<int, InventoryItem2> returnValue= new Dictionary<int, InventoryItem2>();
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].IsEmpty)
            {
                continue;
            }
                
                returnValue[i] = inventoryItems[i];
        }
        return returnValue;
        
    }

    public InventoryItem2 GetItemAt(int itemIndex)
    {
        return inventoryItems[itemIndex];
    }
}
[Serializable]
public struct InventoryItem2
{
    public ItemSO item;
    public bool IsEmpty => item == null;

    public static InventoryItem2 GetEmptyItem()
    => new InventoryItem2
    {
        item = null,
    };
}