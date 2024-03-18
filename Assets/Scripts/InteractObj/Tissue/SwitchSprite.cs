using System.Collections;
using System.Collections.Generic;
using GameState;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SwitchSprite : MonoBehaviour
{
    public UnityEvent<FirstDayGameState> OnSpecialSpriteRevealed;
    [SerializeField] private Sprite[] patternList;
    [SerializeField] private GameObject fragment;
    [SerializeField] private GameObject tissueBox;
    private int index;

    void Start()
    {
        index = -1;
    }
    public void ClickToSwitchSprite()
    {
        if (patternList.Length == 0 || index == patternList.Length)
        {
            fragment.SetActive(true);
            tissueBox.SetActive(false);
            OnSpecialSpriteRevealed?.Invoke(FirstDayGameState.Clinic);
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = patternList[++index];
        }
    }

}
