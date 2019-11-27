using UnityEngine;
using System.Collections;
using Tower;

public class DebugFloorChange : MonoBehaviour
{
    public int floor = 1;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        Stair.ComeUp(floor);
        //Player.Instance.mPlayerData.CurrntFloor.Value = floor;
        //Player.Instance.InitPlayerTilePos();
    }
}
