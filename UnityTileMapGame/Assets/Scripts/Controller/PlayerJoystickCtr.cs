namespace Tower
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerJoystickCtr : MonoBehaviour
    {
        public ETCJoystick PlayerETCJoystick;
        void Start()
        {
            PlayerETCJoystick.OnPressUp.AddListener(Player.Instance.PressUp);
            PlayerETCJoystick.OnPressDown.AddListener(Player.Instance.PressDown);
            PlayerETCJoystick.OnPressLeft.AddListener(Player.Instance.PressLeft);
            PlayerETCJoystick.OnPressRight.AddListener(Player.Instance.PressRight);
        }
    }
}