using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class BrochureInteractionManager : MonoBehaviour
{
    //Brochure
    [SerializeField] private string[] names;
    [SerializeField] private string[] informations;
    [SerializeField] private string[] introductions;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI informationText;
    [SerializeField] private TextMeshProUGUI introductionText;
    [SerializeField] private UnityEvent onFinishReadingBrochure;
    private int index;
    private void Start()
    {
        index = 0;
    }
    
    public void FlipBrochure()
    {
        if (index < names.Length - 1)
        {
            index += 1;
            nameText.text = names[index];
            informationText.text = informations[index];
            introductionText.text = introductions[index];
        }
    }

    public void CloseBrochure()
    {
        if (index >= names.Length - 1)
        {
            onFinishReadingBrochure?.Invoke();
        }

        InitiateBrochure();
    }
    
    public void InitiateBrochure()
    {
        index = 0;
        nameText.text = names[index];
        informationText.text = informations[index];
        introductionText.text = introductions[index];
    }
}
