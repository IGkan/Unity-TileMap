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

        public StringReactiveProperty Name = new StringReactiveProperty("Mr Li");
        public IntReactiveProperty Level = new IntReactiveProperty(1);
        public IntReactiveProperty Life = new IntReactiveProperty(100);
        public IntReactiveProperty Attack = new IntReactiveProperty(2);
        public IntReactiveProperty Defend = new IntReactiveProperty(2);
        public IntReactiveProperty Experience = new IntReactiveProperty(0);
        public IntReactiveProperty Gold = new IntReactiveProperty(0);
        public IntReactiveProperty YellowKey = new IntReactiveProperty(1);
        public IntReactiveProperty RedKey = new IntReactiveProperty(1);
        public IntReactiveProperty PurpleKey = new IntReactiveProperty(1);

        public void InitPlayerData()
        {
            Name.Value = "Mr Li";
            Level.Value = 1;
            Life.Value = 100;
            Attack.Value = 2;
            Defend.Value = 2;
            Experience.Value = 0;
            Gold.Value = 0;
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