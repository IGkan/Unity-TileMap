using QF;
using QF.Extensions;
using UniRx;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Tower
{
    [System.Serializable]
    public class PlayerData
    {
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
            Attack.Value = 10 + Level.Value * 5;
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


        public void AddHideObjPos(Vector3 pos)
        {
            var tileData = new TileData();
            tileData.TileHidePos.Value = pos;
            TileDataCollection.Add(tileData);
        }

        public void SavePlayerData()
        {
            PlayerPrefs.SetString("PlayerTileData", this.ToJson());
        }


        public PlayerData LoadPlayerData()
        {
            var jsonContent = PlayerPrefs.GetString("PlayerTileData", string.Empty);
            if (jsonContent.IsNullOrEmpty())
            {
                InitPlayerData();
                return new PlayerData();
            }
            else
            {


                PlayerData playerData = jsonContent.FromJson<PlayerData>();
                return playerData;

                #region
                //Name.Value = playerData.Name.Value;
                //CurrntFloor.Value = playerData.CurrntFloor.Value;
                //Level.Value = playerData.Level.Value;
                //Attack.Value = playerData.Attack.Value;
                //Defend.Value = playerData.Defend.Value;
                //Life.Value = playerData.Life.Value;
                //Experience.Value = playerData.Experience.Value;
                //Gold.Value = playerData.Gold.Value;
                //YellowKey.Value = playerData.YellowKey.Value;
                //RedKey.Value = playerData.RedKey.Value;
                //PurpleKey.Value = playerData.PurpleKey.Value;

                //NewGame.Value = playerData.NewGame.Value;
                //SoundOn.Value = playerData.SoundOn.Value;
                //MoveSpeed.Value = playerData.MoveSpeed.Value;
                //MaxFloor.Value = playerData.MaxFloor.Value;
                //CanSelectFloor.Value = playerData.CanSelectFloor.Value;
                //CanPeepMonster.Value = playerData.CanPeepMonster.Value;

                //AddAttack.Value = playerData.AddAttack.Value;
                //AddDefend.Value = playerData.AddDefend.Value;
                //AddLife.Value = playerData.AddLife.Value;
                //AddYellowKey.Value = playerData.AddYellowKey.Value;
                //AddRedKey.Value = playerData.AddRedKey.Value;
                //AddYellowKey.Value = playerData.AddYellowKey.Value;
                //AddLevel.Value = playerData.AddLevel.Value;
                //GoldCharge.Value = playerData.GoldCharge.Value;
                //ExperienceCharge.Value = playerData.ExperienceCharge.Value;

                //TileDataCollection = playerData.TileDataCollection;
                #endregion
            }

        }

        public class TileData
        {
            // 隐藏的物体的二维坐标
            public Vector3ReactiveProperty TileHidePos = new Vector3ReactiveProperty();
        }
    }
}