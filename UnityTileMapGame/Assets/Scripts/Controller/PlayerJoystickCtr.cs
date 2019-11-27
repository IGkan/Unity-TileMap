namespace Tower
{
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
        //void OnDestroy()
        //{
        //    PlayerETCJoystick.OnPressUp.RemoveListener(Player.Instance.PressUp);
        //    PlayerETCJoystick.OnPressDown.RemoveListener(Player.Instance.PressDown);
        //    PlayerETCJoystick.OnPressLeft.RemoveListener(Player.Instance.PressLeft);
        //    PlayerETCJoystick.OnPressRight.RemoveListener(Player.Instance.PressRight);
        //}

    }
}