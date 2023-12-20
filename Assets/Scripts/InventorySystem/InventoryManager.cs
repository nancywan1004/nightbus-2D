using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private InventoryPage inventoryUI;
    [SerializeField] private int inventorySize = 10;
    [SerializeField] private InventorySO inventoryData;
    [SerializeField] private ItemSO itemso1;//for debug
    [SerializeField] private ItemSO itemso2;//for debug
    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventoryData.Size);
        inventoryData.Initialize();
        inventoryData.AddItem(itemso1);//for debug
        inventoryData.AddItem(itemso2);//for debug
        foreach (var item in inventoryData.GetCurrentInventoryState())
        {
            inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage);
        }
    }

}
