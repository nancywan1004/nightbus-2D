using System;
using UnityEngine;

namespace InventorySystem.UI
{
    public interface IInventoryPage
    {
        event Action<int> OnDescriptionRequested;
        event Action<int> OnItemActionRequested;
        event Action<int> OnStartDragging;
        event Action<int> OnInteractRequested;
        void InitializeInventoryUI(int inventorysize);
        void UpdateData(int itemIndex, Sprite itemImage);
        void UpdateDescription(int itemIndex, string description);

    }
}