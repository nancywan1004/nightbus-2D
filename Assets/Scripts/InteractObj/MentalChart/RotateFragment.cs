using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFragment : MonoBehaviour
{
    [SerializeField] private GameObject fragment;
    private int referNum = 2;
    public void ClockWiseRotate()
    {

        fragment.transform.Rotate(new Vector3(0, 0,-90));
        referNum++;
        if(referNum%4==0)
        {
            Destroy(gameObject);
        }
            
    }
    public void AntiClockWiseRotate()
    {
        fragment.transform.Rotate(new Vector3(0, 0, 90));
        referNum--;
        if (referNum % 4 == 0)
        {
            Destroy(gameObject);
        }
    }
}
