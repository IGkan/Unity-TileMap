using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    TileDataMsg TDM;
    ITilemap tileMap;
    TileData tiledata;
    private void Start()
    {
        TDM = new TileDataMsg();
        tiledata = new TileData();
    }

    void Update()
    {
       
       TDM.GetTileData(new Vector3Int(0,-4,0), tileMap ,ref tiledata);
        Debug.Log(tiledata.gameObject.name);
    }
    }

