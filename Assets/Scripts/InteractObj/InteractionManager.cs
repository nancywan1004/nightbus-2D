using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour
{
    //

    //BrochureÐû´«ÊÖ²á
    [SerializeField] private string[] names;
    [SerializeField] private string[] informations;
    [SerializeField] private string[] introductions;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI informationText;
    [SerializeField] private TextMeshProUGUI introductionText;
    private int index;
    private void Start()
    {
        index = 0;
    }
    public void FlipBrochure()
    {
        if(index<names.Length-1)
        {
            index += 1;
            nameText.text = names[index];
            informationText.text = informations[index];
            introductionText.text = introductions[index];
        }
        
    }
    public void InitiateBrochure()
    {
        index=0;
        nameText.text = names[index];
        informationText.text = informations[index];
        introductionText.text = introductions[index];
    }
}
