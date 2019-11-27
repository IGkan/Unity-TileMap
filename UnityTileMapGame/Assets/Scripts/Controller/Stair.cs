namespace Tower
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Stair : MonoBehaviour
    {
        public  void  ChangeStair(string name)
        {
            switch (name)
            {
                case "stair_0": // 向下移动
                    Player.Instance.mPlayerData.CurrntFloor.Value -= 1;
                    ComeDown(Player.Instance.mPlayerData.CurrntFloor.Value);
                    break;
                case "stair_1": // 向上移动
                    Player.Instance.mPlayerData.CurrntFloor.Value += 1;
                    ComeUp(Player.Instance.mPlayerData.CurrntFloor.Value);
                    break;
                default:
                    break;
            }
        }

        private static void InitPlayerTilePosAndCamera(int targetFloor)
        {
            Camera.main.transform.position = new Vector3(0.5f + (targetFloor - 1) * 12, 0.56f, -10);
            Player.Instance.InitPlayerTilePos();
            Player.Instance.mPlayerData.CurrntFloor.Value = targetFloor;

        }

        public static void ComeUp(int targetFloor)
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
                case 9:
                    Player.Instance.transform.position = new Vector3(91.5f, -3.5f, 0);
                    break;
                case 10:
                    Player.Instance.transform.position = new Vector3(103.5f, -3.5f, 0);
                    break;
                case 11:
                    Player.Instance.transform.position = new Vector3(124.5f, -3.5f, 0);
                    break;
                case 12:
                    Player.Instance.transform.position = new Vector3(128.5f,-4.5f, 0);
                    break;
                case 13:
                    Player.Instance.transform.position = new Vector3(141.5f, -1.5f, 0);
                    break;
                case 14:
                    Player.Instance.transform.position = new Vector3(151.5f, -3.5f, 0);
                    break;
                case 15:
                    Player.Instance.transform.position = new Vector3(164.5f, -4.5f, 0);
                    break;
                case 16:
                    Player.Instance.transform.position = new Vector3(178.5f, -2.5f, 0);
                    break;
                case 17:
                    Player.Instance.transform.position = new Vector3(188.5f, -4.5f, 0);
                    break;
                case 18:
                    Player.Instance.transform.position = new Vector3(209.5f,4.5f, 0);
                    break;
                case 19:
                    Player.Instance.transform.position = new Vector3(218.5f, 8.5f, 0);
                    break;
                case 20:
                    Player.Instance.transform.position = new Vector3(224.5f, -4.5f, 0);
                    break;
                case 21:
                    Player.Instance.transform.position = new Vector3(236.5f, -4.5f, 0);
                    break;
                case 22:
                    Player.Instance.transform.position = new Vector3(253.5f, 4.5f, 0);
                    break;
                case 23:
                    Player.Instance.transform.position = new Vector3(260.5f, -4.5f, 0);
                    break;
                case 24:
                    Player.Instance.transform.position = new Vector3(272.5f, -4.5f, 0);
                    break;
                case 25:
                    Player.Instance.transform.position = new Vector3(284.5f, -4.5f, 0);
                    break;
                case 26:
                    Player.Instance.transform.position = new Vector3(295.5f, -3.5f, 0);
                    break;
            }

            InitPlayerTilePosAndCamera(targetFloor);
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
                case 9:
                    Player.Instance.transform.position = new Vector3(100.5f, 11.5f, 0);
                    break;
                case 10:
                    Player.Instance.transform.position = new Vector3(112.5f,11.5f, 0);
                    break;
                case 11:
                    Player.Instance.transform.position = new Vector3(125.5f, 10.5f, 0);
                    break;
                case 12:
                    Player.Instance.transform.position = new Vector3(137.5f, 10.5f, 0);
                    break;
                case 13:
                    Player.Instance.transform.position = new Vector3(147.5f, 8.5f, 0);
                    break;
                case 14:
                    Player.Instance.transform.position = new Vector3(161.5f, -0.5f, 0);
                    break;
                case 15:
                    Player.Instance.transform.position = new Vector3(166.5f, 10.5f, 0);
                    break;
                case 16:
                    Player.Instance.transform.position = new Vector3(179.5f, 2.5f, 0);
                    break;
                case 17:
                    Player.Instance.transform.position = new Vector3(197.5f, 10.5f, 0);
                    break;
                case 18:
                    Player.Instance.transform.position = new Vector3(208.5f, -4.5f, 0);
                    break;
                case 19:
                    Player.Instance.transform.position = new Vector3(221.5f, 10.5f, 0);
                    break;
                case 20:
                    Player.Instance.transform.position = new Vector3(232.5f, 11.5f, 0);
                    break;
                case 21:
                    Player.Instance.transform.position = new Vector3(245.5f, 10.5f, 0);
                    break;
                case 22:
                    Player.Instance.transform.position = new Vector3(257.5f, 10.5f, 0);
                    break;
                case 23:
                    Player.Instance.transform.position = new Vector3(269.5f, 10.5f, 0);
                    break;
                case 24:
                    Player.Instance.transform.position = new Vector3(281.5f, 10.5f, 0);
                    break;
                case 25:
                    Player.Instance.transform.position = new Vector3(293.5f, -0.5f, 0);
                    break;
                case 26:
                    Player.Instance.transform.position = new Vector3(285.5f, -4.5f, 0);
                    break;
            }
            InitPlayerTilePosAndCamera(targetFloor);
        }
    }

}