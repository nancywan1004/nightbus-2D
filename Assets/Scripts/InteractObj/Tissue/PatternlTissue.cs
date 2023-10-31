using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PatternTissue : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [SerializeField] private float dragDistance;
    [SerializeField] private GameObject PatternTissueObj;
    public static GameObject itemBeginDragged;
    private Vector3 startPos;
    public float CalculateDistance(Vector3 p1, Vector3 p2)
    {
        float x = p1.x - p2.x;
        float y = p1.y - p2.y;
        return Mathf.Sqrt(x * x + y * y);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeginDragged = gameObject;
        startPos=transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(CalculateDistance(transform.position,startPos)> dragDistance) 
        {
            itemBeginDragged = null;
            PatternTissueObj.SetActive(true);
            Destroy(gameObject);
        }
    }

}
