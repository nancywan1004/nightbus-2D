using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Inventory.UI
{
    public class InventoryDescription : MonoBehaviour
    {
        [SerializeField] private TMP_Text description;

        public void Awake()
        {
            ResetDescription();
        }

        public void ResetDescription()
        {
            description.text = "";
        }

        public void SetDescription(string itemDescription)
        {
            description.text = itemDescription;
        }
    }
}