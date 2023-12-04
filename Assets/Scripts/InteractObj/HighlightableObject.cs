using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightableObject : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    private Image _image;
    private static readonly int Thickness = Shader.PropertyToID("_Thickness");

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Activate()
    {
        _image.material.SetFloat(Thickness, 2.5f);
    }

    public void Deactivate()
    {
        _image.material.SetFloat(Thickness, 0f);
    }

    public void OnSelect(BaseEventData eventData)
    {
        Activate();
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Deactivate();
    }
}
