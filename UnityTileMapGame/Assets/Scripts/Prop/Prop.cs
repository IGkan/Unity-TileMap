namespace Tower
{
    using QF;
    using QF.Extensions;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Prop : MonoBehaviour,ISingleton
    {
        public static Prop Instance
        {
            get { return MonoSingletonProperty<Prop>.Instance; }
        }
        public string Name;
        public int Life;
        public int Attack;
        public int Defend;
        public int Level;
        public int Experience;
        public int Gold;
        public int YellowKey;
        public int RedKey;
        public int PurpleKey;

        private void Reset()
        {
            Name = transform.name;
        }

        public void PropExecute(string name)
        {
            gameObject.Hide();
<<<<<<< HEAD
            Player.Instance.mPlayerData.AddHideObjPos(gameObject.transform.localPosition);
=======
            //PlayerData.Instance.AddHideObjPos(gameObject.transform.localPosition);
>>>>>>> 8207420c391999537d5f8dbc19fe02f937f6ba2d
            switch (name)
            {
                case "Life":
                    Player.Instance.mPlayerData.Life.Value += this.Life;
                    break;
                case "Attack":
                    Player.Instance.mPlayerData.Attack.Value += this.Attack;
                    break;
                case "Defend":
                    Player.Instance.mPlayerData.Defend.Value += this.Defend;
                    break;
                case "Level":
                    Player.Instance.mPlayerData.Level.Value += this.Level;
                    break;
                case "Experience":
                    Player.Instance.mPlayerData.Experience.Value += this.Experience;
                    break;
                case "Gold":
                    Player.Instance.mPlayerData.Gold.Value += this.Gold;
                    break;
                case "YellowKey":
                    Player.Instance.mPlayerData.YellowKey.Value += this.YellowKey;
                    break;
                case "RedKey":
                    Player.Instance.mPlayerData.RedKey.Value += this.RedKey;
                    break;
                case "PurpleKey":
                    Player.Instance.mPlayerData.PurpleKey.Value += this.PurpleKey;
                    break;
                case "SelectLevel":
                    Player.Instance.mPlayerData.CanSelectFloor.Value = true;
                    break;
                case "PeepMonster":
                    Player.Instance.mPlayerData.CanPeepMonster.Value = true;
                    break;
                default:
                    break;
            }
        }

        public void OnSingletonInit()
        {
        }
    }

}