using Inventory.UI;
using Inventory.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private InventoryPage inventoryUI;
        [SerializeField] private int inventorySize = 10;
        [SerializeField] private InventorySO inventoryData;
        [SerializeField] private ItemSO itemso1;//for debug
        [SerializeField] private ItemSO itemso2;//for debug
        private void Start()
        {
            PrepareUI();
            inventoryData.Initialize();
            inventoryData.AddItem(itemso1);//for debug
            inventoryData.AddItem(itemso2);//for debug
            foreach (var item in inventoryData.GetCurrentInventoryState())
            {
                inventoryUI.UpdateData(item.Key, item.Value.item.ItemImage);
            }
        }
        private void PrepareUI()
        {
            inventoryUI.InitializeInventoryUI(inventoryData.Size);
            inventoryUI.OnDescriptionRequested += HandleDescriptionRequest;
            inventoryUI.OnItemActionRequested += HandleItemActionRequest;
            inventoryUI.OnStartDragging += HandleDragging;
            inventoryUI.OnInteractRequested += HandleInteractionRequest;
        }

        private void HandleInteractionRequest(int itemIndex)
        {

        }

        private void HandleDragging(int itemIndex)
        {

        }

        private void HandleItemActionRequest(int itemIndex)
        {

        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem2 inventoryItem = inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                return;
            }
            ItemSO item = inventoryItem.item;
            inventoryUI.UpdateDescription(itemIndex, item.Description);

        }
    }
}