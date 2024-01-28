using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchSprite : MonoBehaviour
{
    private Sprite pattern1,pattern2,pattern3,pattern4;
    private Sprite[] patternList ;
    [SerializeField] private GameObject fragment;
    [SerializeField] private GameObject tissueBox;
    private int index;

    void Start()
    {
        index = -1;
        pattern1 = Resources.Load<Sprite>("Temporary/PatternTissue2") as Sprite;
        pattern2 = Resources.Load<Sprite>("Temporary/PatternTissue3") as Sprite;
        pattern3 = Resources.Load<Sprite>("Temporary/PatternTissue4") as Sprite;
        pattern4 = Resources.Load<Sprite>("Temporary/PatternTissue5") as Sprite;
        patternList = new Sprite[] { pattern1, pattern2, pattern3, pattern4 };
    }
    public void ClickToSwitchSprite()
    {

        if (index < 4)
        {
            index += 1;
        }
        if (index < 4)
        {
            gameObject.GetComponent<Image>().sprite = patternList[index];
        }
        if (index==4)
        {
            fragment.SetActive(true);
            tissueBox.SetActive(false);
            Destroy(gameObject);
        }
    }

}
