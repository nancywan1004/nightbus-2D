using UnityEngine;

public class DraggableBackground : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    // Define the boundaries for dragging
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f;
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f;

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 targetPos = GetMouseWorldPos() + offset;

            // Clamp the position within the specified boundaries
            targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
            targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

            transform.position = targetPos;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}