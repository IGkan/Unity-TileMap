using QF;
using QF.Extensions;
using UniRx;
using UnityEngine;

namespace Tower
{
    [System.Serializable]
    public class PlayerData : ISingleton
    {
        private PlayerData() { }
        public static PlayerData Instance
        {
            get
            {
                return SingletonProperty<PlayerData>.Instance;
            }
        }

        #region 属性
        // 玩家属性
        public StringReactiveProperty Name = new StringReactiveProperty();
        public IntReactiveProperty CurrntFloor = new IntReactiveProperty();
        public IntReactiveProperty Level = new IntReactiveProperty();
        public IntReactiveProperty Life = new IntReactiveProperty();
        public IntReactiveProperty Attack = new IntReactiveProperty();
        public IntReactiveProperty Defend = new IntReactiveProperty();
        public IntReactiveProperty Experience = new IntReactiveProperty();
        public IntReactiveProperty Gold = new IntReactiveProperty();
        public IntReactiveProperty YellowKey = new IntReactiveProperty();
        public IntReactiveProperty RedKey = new IntReactiveProperty();
        public IntReactiveProperty PurpleKey = new IntReactiveProperty();


        // 玩家其他相关属性
        public BoolReactiveProperty NewGame = new BoolReactiveProperty(); // 是否新游戏
        public FloatReactiveProperty MoveSpeed = new FloatReactiveProperty(0.2f); // 玩家移动速度
        public IntReactiveProperty MaxFloor = new IntReactiveProperty(); // 游戏最大关卡数
        public BoolReactiveProperty CanSelectFloor = new BoolReactiveProperty(); // 是否吃到道具可以自由选择关卡
        public BoolReactiveProperty CanPeepMonster = new BoolReactiveProperty(); // 是否吃到道具可以查看怪物信息和对玩家的预计伤害等

        //public BoolReactiveProperty IsGaming = new BoolReactiveProperty(); // 是否一直在游戏中

        // 商店购买使用的属性
        public IntReactiveProperty AddAttack = new IntReactiveProperty();
        public IntReactiveProperty AddDefend = new IntReactiveProperty();
        public IntReactiveProperty AddLife = new IntReactiveProperty();
        public IntReactiveProperty AddYellowKey = new IntReactiveProperty();
        public IntReactiveProperty AddRedKey = new IntReactiveProperty();
        public IntReactiveProperty AddPurpleKey = new IntReactiveProperty();
        public IntReactiveProperty AddLevel = new IntReactiveProperty();
        public IntReactiveProperty GoldCharge = new IntReactiveProperty(); // 购买花费的金币 
        public IntReactiveProperty ExperienceCharge = new IntReactiveProperty(); //购买花费的经验


        #endregion

     
        // 新游戏初始化数据
        public void InitPlayerData()
        {
            Name.Value = "Mr Li";
            CurrntFloor.Value = 1;
            Level.Value = 1;
            Attack.Value = 10 + Level.Value*5;
            Defend.Value = 10 + Level.Value * 5;
            Life.Value = 100 + Level.Value * 50;
            Experience.Value = 0;
            Gold.Value = 0;
            YellowKey.Value = 0;
            RedKey.Value = 0;
            PurpleKey.Value = 0;

            NewGame.Value = true;
            MaxFloor.Value = 26;
            CanSelectFloor.Value = false;
            CanPeepMonster.Value = false;

            AddAttack.Value = 10;
            AddDefend.Value = 10;
            AddLife.Value = 100;
            AddYellowKey.Value = 1;
            AddRedKey.Value = 1;
            AddYellowKey.Value = 1;
            GoldCharge.Value = 100;
            ExperienceCharge.Value = 100;

            Player.Instance.InitPlayerTilePos();
            Stair.ComeUp(1);
        }

        public ReactiveCollection<TileData> TileDataCollection = new ReactiveCollection<TileData>();

        public void AddHideObjPos(Vector2 pos)
        {
            var tileData = new TileData();
            tileData.TileHidePos.Value = pos;
            TileDataCollection.Add(tileData);
        }

        public void SavePlayerData()
        {
            PlayerPrefs.SetString("PlayerTileData", this.ToJson());
        }
        

        public void LoadPlayerData()
        {
            var jsonContent = PlayerPrefs.GetString("PlayerTileData", string.Empty);
  
            if (!NewGame.Value)
            {
                foreach (var item in jsonContent.FromJson<PlayerData>().TileDataCollection)
                {
                    RaycastHit2D hit = Physics2D.Raycast(item.TileHidePos.Value, Vector2.zero);
                    if (hit.collider != null)
                    {
                        Debug.Log("加载数据隐藏: " + hit.collider.gameObject.name);
                        hit.collider.gameObject.SetActive(false);
                    }
                }
            }
        }
        public void OnSingletonInit()
        {

        }
    }

    public class TileData{
        // 隐藏的物体的二维坐标
        public Vector3ReactiveProperty TileHidePos = new Vector3ReactiveProperty();
    }
}