using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDescription : MonoBehaviour
{
    [SerializeField] private TMP_Text description;

    public void Awake()
    {
        ResetDescription();
    }

    public void ResetDescription()
    {
        this.description.text = "";
    }

    public void SetDescription(string itemDescription)
    {
        this.description.text = itemDescription;
    }
}
