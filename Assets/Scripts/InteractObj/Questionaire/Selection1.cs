using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selection1 : MonoBehaviour
{
    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;
    public void SelectButton1()
    {
        button1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans1_sel");
        button2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans2_nml");
        button3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans3_nml");
    }
    public void SelectButton2()
    {
        button1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans1_nml");
        button2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans2_sel");
        button3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans3_nml");
    }
    public void SelectButton3()
    {
        button1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans1_nml");
        button2.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans2_nml");
        button3.GetComponent<Image>().sprite = Resources.Load<Sprite>("Questionaire/ques_btn_ans3_sel");
    }
}
