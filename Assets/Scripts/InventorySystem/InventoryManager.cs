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
        public static InventoryManager Instance { get; private set; }
        [SerializeField] private InventoryPage inventoryUI;
        [SerializeField] private int inventorySize = 10;
        [SerializeField] private InventorySO inventoryData;
        [SerializeField] private ItemSO itemso1;//for debug
        [SerializeField] private ItemSO itemso2;//for debug

        public void AddToInventoryData(ItemSO item)
        {
            if (inventoryData == null)
            {
                Debug.LogError("Found no InventorySO");
                return;
            }
            inventoryData.AddItem(item);
            RefreshInventoryUIPanel();
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogWarning("Found more than one Inventory Manager in the scene");
            }
            Instance = this;
        }

        private void Start()
        {
            PrepareUI();
            inventoryData.Initialize();
            //inventoryData.AddItem(itemso1);//for debug
            //inventoryData.AddItem(itemso2);//for debug
            RefreshInventoryUIPanel();
        }

        private void RefreshInventoryUIPanel()
        {
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