namespace Tower
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Stair : MonoBehaviour
    {
        public void ChangeStair(string name)
        {
            switch (name)
            {
                case "stair_0": // 向下移动
                    PlayerData.Instance.CurrntFloor.Value -= 1;
                    ComeDown(PlayerData.Instance.CurrntFloor.Value);
                    Camera.main.transform.position = new Vector3(0.5f + (PlayerData.Instance.CurrntFloor.Value - 1) * 12, 0.56f, -10);
                    break;
                case "stair_1": // 向上移动
                    PlayerData.Instance.CurrntFloor.Value += 1;
                    ComeUp(PlayerData.Instance.CurrntFloor.Value);
                    Camera.main.transform.position = new Vector3(0.5f + (PlayerData.Instance.CurrntFloor.Value - 1) * 12, 0.56f, -10);
                    break;
                default:
                    break;
            }
            Player.Instance.InitPlayerTilePos();
        }


        void ComeUp(int targetFloor)
        {
            switch (targetFloor)
            {
                case 1:
                    Player.Instance.transform.position = new Vector3(0.5f , -4.5f, 0);
                    break;
                case 2:
                    Player.Instance.transform.position = new Vector3(12.5f, -3.5f, 0);
                    break;
                case 3:
                    Player.Instance.transform.position = new Vector3(20.5f, 11.5f, 0);
                    break;
                case 4:
                    Player.Instance.transform.position = new Vector3(40.5f, -4.5f, 0);
                    break;
                case 5:
                    Player.Instance.transform.position = new Vector3(44.5f, -4.5f, 0);
                    break;
                case 6:
                    Player.Instance.transform.position = new Vector3(56.5f, -4.5f, 0);
                    break;
                case 7:
                    Player.Instance.transform.position = new Vector3(77.5f, 10.5f, 0);
                    break;
                case 8:
                    Player.Instance.transform.position = new Vector3(80.5f, -0.5f, 0);
                    break;

            }
        }

        void ComeDown(int targetFloor)
        {
            switch (targetFloor)
            {
                case 1:
                    Player.Instance.transform.position = new Vector3(0.5f, 10.5f, 0);
                    break;
                case 2:
                    Player.Instance.transform.position = new Vector3(16.5f, 11.5f, 0);
                    break;
                case 3:
                    Player.Instance.transform.position = new Vector3(20.5f, -4.5f, 0);
                    break;
                case 4:
                    Player.Instance.transform.position = new Vector3(40.5f, 11.5f, 0);
                    break;
                case 5:
                    Player.Instance.transform.position = new Vector3(52.5f, -4.5f, 0);
                    break;
                case 6:
                    Player.Instance.transform.position = new Vector3(57.5f, 4.5f, 0);
                    break;
                case 7:
                    Player.Instance.transform.position = new Vector3(68.5f, 11.5f, 0);
                    break;
                case 8:
                    Player.Instance.transform.position = new Vector3(80.5f, -4.5f, 0);
                    break;
            }
        }
    }

}