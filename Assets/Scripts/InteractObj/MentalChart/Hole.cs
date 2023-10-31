using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hole : MonoBehaviour,IDropHandler
{
    [SerializeField] private GameObject rotationButton;
    [SerializeField] private GameObject fragment;
    public GameObject item
    {
        get
        {
            if (transform.childCount>0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop");
        Fragment.itemBeginDragged.transform.SetParent(transform);
        Fragment.itemBeginDragged.transform.localPosition = Vector3.zero;
        Fragment.itemBeginDragged.transform.localScale= new Vector3 (1.5f,1.5f,1);
        Fragment.itemBeginDragged.transform.localRotation=Quaternion.Euler(0,0,180);
        rotationButton.SetActive(true);
        Destroy(fragment.GetComponent<Fragment>());

    }
}
