using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hole : MonoBehaviour,IDropHandler
{
    [SerializeField] private Sprite mentalChartWithBus;
    [SerializeField] private RotateFragment rotationButton;
    [SerializeField] private Fragment fragment;
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
        Transform itemDragged = Fragment.itemBeginDragged.transform;
        itemDragged.SetParent(transform);
        itemDragged.localPosition = Vector3.zero;
        itemDragged.localScale= new Vector3 (1.5f,1.5f,1);
        itemDragged.localRotation=Quaternion.Euler(0,0,180);
        rotationButton.gameObject.SetActive(true);
        rotationButton.OnRotationComplete += SwapMentalChartBackground;
        Destroy(fragment);
    }

    private void SwapMentalChartBackground(GameObject droppedFragment)
    {
        Destroy(droppedFragment);
        transform.parent.GetComponent<Image>().sprite = mentalChartWithBus;
    }

    private void OnDestroy()
    {
        rotationButton.OnRotationComplete -= SwapMentalChartBackground;
    }
}
