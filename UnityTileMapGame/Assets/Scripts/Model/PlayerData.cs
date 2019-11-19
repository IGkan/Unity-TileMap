using QF;
using UniRx;
using UnityEngine;
using QF.Extensions;

namespace Tower
{
    [System.Serializable]
    public class PlayerData : ISingleton
    {
        private PlayerData() { }
        // 玩家属性
        public BoolReactiveProperty NewGame = new BoolReactiveProperty(true);
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

        // 商店购买使用的属性
        public IntReactiveProperty AddAttack = new IntReactiveProperty(10);
        public IntReactiveProperty AddDefend = new IntReactiveProperty(10);
        public IntReactiveProperty AddLife = new IntReactiveProperty(100);
        public IntReactiveProperty AddYellowKey = new IntReactiveProperty(1);
        public IntReactiveProperty AddRedKey = new IntReactiveProperty(1);
        public IntReactiveProperty AddPurpleKey = new IntReactiveProperty(1);
        public IntReactiveProperty AddLevel = new IntReactiveProperty(1);
        public IntReactiveProperty GoldCharge = new IntReactiveProperty(100); // 购买花费的金币 
        public IntReactiveProperty ExperienceCharge = new IntReactiveProperty(100); //购买花费的经验
        public void InitPlayerData()
        {
            NewGame.Value = true;
            Name.Value = "Mr Li";
            CurrntFloor.Value = 1;
            Level.Value = 1;
            Life.Value = 100;
            Attack.Value = 10;
            Defend.Value = 10;
            Experience.Value = 0;
            Gold.Value = 0;
            YellowKey.Value = 0;
            RedKey.Value = 0;
            PurpleKey.Value = 0;
        }

        public static PlayerData Instance
        {
            get
            {
                return SingletonProperty<PlayerData>.Instance;
            }
        }

        //public void SavePlayerData()
        //{
        //    PlayerPrefs.SetString("PlayerData", this.ToJson());
        //}

        //public PlayerData LoadPlayerData()
        //{
        //    var jsonContent = PlayerPrefs.GetString("PlayerData", string.Empty);
        //    return jsonContent.IsNullOrEmpty() ? new PlayerData() : jsonContent.FromJson<PlayerData>();
        //}
        public void OnSingletonInit()
        {

        }
    }
}