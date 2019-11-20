using UnityEngine;
using System.Collections;
using Tower;
using static ETCJoystick;

public class Test : MonoBehaviour
{
    //public delegate OnPressDownHandler onPressDown();
    //public static event onPressDown MyPressDown;
    void Start()
    {

        //MyPressDown += PressDown;
    }

    private void FixedUpdate()
    {
        //Debug.Log(ETCInput.GetAxis("Vertical"));
    }
    public void PressUp()
    {
        Debug.Log("PressUp");
    }
    public void PressDown()
    {
        Debug.Log("PressDown");
    }
    public void PressLeft()
    {
        Debug.Log("PressLeft");
    }
    public void PressRight()
    {
        Debug.Log("PressRight");
    }
}

