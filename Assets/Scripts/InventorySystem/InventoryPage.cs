using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class InventoryPage : MonoBehaviour
    {
        [SerializeField] private InventoryItem itemPrefab;
        [SerializeField] private RectTransform contentPanel;
        [SerializeField] private InventoryDescription itemDescription;
        [SerializeField] private MouseFollower mouseFollower;
        List<InventoryItem> listOfUIItems = new List<InventoryItem>();
        //public Sprite image;
        //public string description;
        private int currentlyDraggedItemIndex = -1;

        public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging, OnInteractRequested;

        private void Start()
        {
            ResetSelection();

        }
        private void Awake()
        {
            mouseFollower.Toggle(false);
            itemDescription.ResetDescription();
        }
        public void InitializeInventoryUI(int inventorysize)
        {
            for (int i = 0; i < inventorysize; i++)
            {
                InventoryItem uiItem = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity);
                uiItem.transform.SetParent(contentPanel);
                listOfUIItems.Add(uiItem);
                uiItem.OnItemClicked += HandleItemSelection;
                uiItem.OnItemBeginDrag += HandleBeginDrag;
                uiItem.OnItemEndDrag += HandleEndDrag;
                uiItem.OnItemDroppedOn += HandleInteraction;
            }
        }

        public void UpdateData(int itemIndex, Sprite itemImage)
        {
            if (listOfUIItems.Count > itemIndex)
            {
                listOfUIItems[itemIndex].SetData(itemImage);
            }
        }
        private void HandleItemSelection(InventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
                return;
            OnDescriptionRequested?.Invoke(index);
        }

        private void HandleBeginDrag(InventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }
            currentlyDraggedItemIndex = index;
            HandleItemSelection(inventoryItemUI);
            OnStartDragging?.Invoke(index);
        }

        public void CreateDraggedItem(Sprite sprite, int quantity)
        {
            mouseFollower.Toggle(true);
            mouseFollower.SetData(sprite);
        }
        private void HandleEndDrag(InventoryItem inventoryItemUI)
        {
            ResetDraggedItem();
        }
        private void HandleInteraction(InventoryItem inventoryItemUI)
        {
            int index = listOfUIItems.IndexOf(inventoryItemUI);
            if (index == -1)
            {
                return;
            }
            //interaction
            OnInteractRequested?.Invoke(index);
            //mouseFollower.Toggle(false);
            //currentlyDraggedItemIndex = -1;
        }
        private void ResetDraggedItem()
        {

        }
        private void ResetSelection()
        {
            itemDescription.ResetDescription();
            DeselectAllItems();
        }
        private void DeselectAllItems()
        {
            foreach (InventoryItem item in listOfUIItems)
            {
                item.Deselect();
            }
        }

        internal void UpdateDescription(int itemIndex, string description)
        {
            itemDescription.SetDescription(description);
            DeselectAllItems();

        }
    }
}