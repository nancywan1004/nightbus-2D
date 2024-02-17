using System;
using UnityEngine;

public class RotateFragment : MonoBehaviour
{
    public event Action<GameObject> OnRotationComplete;
    [SerializeField] private GameObject fragment;
    private int referNum = 2;
    
    public void ClockWiseRotate()
    {
        fragment.transform.Rotate(new Vector3(0, 0,-90));
        referNum++;
        if(referNum % 4==0)
        {
            OnRotationComplete?.Invoke(fragment);
            Destroy(gameObject);
        }
    }
    public void AntiClockWiseRotate()
    {
        fragment.transform.Rotate(new Vector3(0, 0, 90));
        referNum--;
        if (referNum % 4 == 0)
        {
            OnRotationComplete?.Invoke(fragment);
            Destroy(gameObject);
        }
    }
}
