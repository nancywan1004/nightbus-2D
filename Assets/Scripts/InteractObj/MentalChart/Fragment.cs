using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fragment : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeginDragged;
    private Vector3 startPos;
    private Transform startParent;

    public void OnBeginDrag(PointerEventData eventData)
    {
     itemBeginDragged = gameObject;
     startPos = transform.position;
     startParent = transform.parent;
     GetComponent<CanvasGroup>().blocksRaycasts = false;

       
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        itemBeginDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if(transform.parent==startParent)
        {
            transform.position=startPos;
        }

    }
}
