using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection2 : MonoBehaviour
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    public void SelectButton1()
    {
        button1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans4_sel");
        button2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans5_nml");
        button3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans6_nml");
    }
    public void SelectButton2()
    {
        button1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans4_nml");
        button2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans5_sel");
        button3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans6_nml");
    }
    public void SelectButton3()
    {
        button1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans4_nml");
        button2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans5_nml");
        button3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans6_sel");
    }
}
