using QF;
using QF.Extensions;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Tower
{
    [System.Serializable]
    public class PlayerData
    {
        //private PlayerData() { }
        //public static PlayerData Instance
        //{
        //    get
        //    {
        //        return SingletonProperty<PlayerData>.Instance;
        //    }
        //}

        #region 属性
        // 玩家基本属性
        public StringReactiveProperty Name = new StringReactiveProperty("Mr Li");
        public IntReactiveProperty CurrntFloor = new IntReactiveProperty(1);
        public IntReactiveProperty Level = new IntReactiveProperty(1);
        public IntReactiveProperty Life = new IntReactiveProperty(100);
        public IntReactiveProperty Attack = new IntReactiveProperty(10);
        public IntReactiveProperty Defend = new IntReactiveProperty(10);
        public IntReactiveProperty Experience = new IntReactiveProperty(0);
        public IntReactiveProperty Gold = new IntReactiveProperty(0);
        public IntReactiveProperty YellowKey = new IntReactiveProperty(0);
        public IntReactiveProperty RedKey = new IntReactiveProperty(0);
        public IntReactiveProperty PurpleKey = new IntReactiveProperty(0);


        // 玩家其他相关属性
        public BoolReactiveProperty NewGame = new BoolReactiveProperty(true); // 是否新游戏
        public BoolReactiveProperty SoundOn = new BoolReactiveProperty(true); // 是否新游戏
        public FloatReactiveProperty MoveSpeed = new FloatReactiveProperty(0.2f); // 玩家移动速度
        public IntReactiveProperty MaxFloor = new IntReactiveProperty(26); // 游戏最大关卡数
        public BoolReactiveProperty CanSelectFloor = new BoolReactiveProperty(false); // 是否吃到道具可以自由选择关卡
        public BoolReactiveProperty CanPeepMonster = new BoolReactiveProperty(false); // 是否吃到道具可以查看怪物信息和对玩家的预计伤害等
        //public Vector3ReactiveProperty mTargetTilePos = new Vector3ReactiveProperty(new Vector3(0, -5f, 0)); // 初始瓦片坐标
        //public BoolReactiveProperty IsGaming = new BoolReactiveProperty(); // 是否一直在游戏中

        // 商店购买使用的属性
        public IntReactiveProperty AddAttack = new IntReactiveProperty(10);
        public IntReactiveProperty AddDefend = new IntReactiveProperty(10);
        public IntReactiveProperty AddLife = new IntReactiveProperty(100);
        public IntReactiveProperty AddYellowKey = new IntReactiveProperty(1);
        public IntReactiveProperty AddRedKey = new IntReactiveProperty(1);
        public IntReactiveProperty AddPurpleKey = new IntReactiveProperty(1);
        public IntReactiveProperty AddLevel = new IntReactiveProperty(100);
        public IntReactiveProperty GoldCharge = new IntReactiveProperty(100); // 购买花费的金币 
        public IntReactiveProperty ExperienceCharge = new IntReactiveProperty(100); //购买花费的经验


        #endregion   
     
        // 新游戏初始化数据
        public void InitPlayerData()
        {
            Name.Value = "Mr Li";
            CurrntFloor.Value = 1;
            Level.Value = 1;
            Attack.Value = 10;
            Defend.Value = 10;
            Life.Value = 150;
            Experience.Value = 0;
            Gold.Value = 0;
            YellowKey.Value = 0;
            RedKey.Value = 0;
            PurpleKey.Value = 0;

            NewGame.Value = true;
            SoundOn.Value = true;
            MoveSpeed.Value = 0.2f;
            MaxFloor.Value = 26;
            CanSelectFloor.Value = false;
            CanPeepMonster.Value = false;

            AddAttack.Value = 10;
            AddDefend.Value = 10;
            AddLife.Value = 100;
            AddYellowKey.Value = 1;
            AddRedKey.Value = 1;
            AddYellowKey.Value = 1;
            AddLevel.Value = 1;
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

        /// <summary>
        /// 保存数据
        /// </summary>
        public void SavePlayerData()
        {
<<<<<<< HEAD

            Debug.Log("数据保存成功！");

=======
            GameScenePrefab.Instance.SetHideSave();
>>>>>>> 8207420c391999537d5f8dbc19fe02f937f6ba2d
            PlayerPrefs.SetString("PlayerTileData", this.ToJson());

        }
        //Transform[] mChildArr;
        // void SetHideSave()
        //{
        //    mChildArr = GameObject.Find("GameScenePrefab(Clone)").GetComponentsInChildren<Transform>();
        //    foreach (Transform item in mChildArr)
        //    {
        //        if (!item.gameObject.activeSelf)
        //        {
        //            Debug.Log(item.localPosition);
        //            PlayerData.Instance.AddHideObjPos(item.localPosition);
        //        }
        //    }
        //}

        /// <summary>
        /// 加载数据
        /// </summary>
        public  PlayerData  LoadPlayerData()
        {
            var jsonContent = PlayerPrefs.GetString("PlayerTileData", string.Empty);
<<<<<<< HEAD
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

        public void LoadTileData() {
            var jsonContent = PlayerPrefs.GetString("PlayerTileData", string.Empty);
            if (!jsonContent.IsNullOrEmpty())
            {
                    foreach (var item in jsonContent.FromJson<PlayerData>().TileDataCollection)
=======
            PlayerData playerData = jsonContent.FromJson<PlayerData>();

            Name.Value = playerData.Name.Value;
            CurrntFloor.Value = playerData.CurrntFloor.Value;
            Level.Value = playerData.Level.Value;
            Attack.Value = playerData.Attack.Value;
            Defend.Value = playerData.Defend.Value;
            Life.Value = playerData.Life.Value;
            Experience.Value = playerData.Experience.Value;
            Gold.Value = playerData.Gold.Value;
            YellowKey.Value = playerData.YellowKey.Value;
            RedKey.Value = playerData.RedKey.Value;
            PurpleKey.Value = playerData.PurpleKey.Value;

            NewGame.Value = playerData.NewGame.Value;
            MaxFloor.Value = playerData.MaxFloor.Value;
            CanSelectFloor.Value = playerData.CanSelectFloor.Value;
            CanPeepMonster.Value = playerData.CanPeepMonster.Value;

            AddAttack.Value = playerData.AddAttack.Value;
            AddDefend.Value = playerData.AddDefend.Value;
            AddLife.Value = playerData.AddLife.Value;
            AddYellowKey.Value = playerData.AddYellowKey.Value;
            AddRedKey.Value = playerData.AddRedKey.Value;
            AddYellowKey.Value = playerData.AddYellowKey.Value;
            GoldCharge.Value = playerData.GoldCharge.Value;
            ExperienceCharge.Value = playerData.ExperienceCharge.Value;

            Player.Instance.InitPlayerTilePos();
            Stair.ComeUp(1);



            if (!NewGame.Value)
            {
                foreach (var item in playerData.TileDataCollection)
                {
                    RaycastHit2D hit = Physics2D.Raycast(item.TileHidePos.Value, Vector2.zero);
                    if (hit.collider != null)
>>>>>>> 8207420c391999537d5f8dbc19fe02f937f6ba2d
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
        //public void OnSingletonInit()
        //{

        //}
    }

    public class TileData{
        // 隐藏的物体的二维坐标
        public Vector3ReactiveProperty TileHidePos = new Vector3ReactiveProperty();
    }
}