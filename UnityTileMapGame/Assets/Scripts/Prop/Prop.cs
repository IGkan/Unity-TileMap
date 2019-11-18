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
            switch (name)
            {
                case "Life":
                    PlayerData.Instance.Life.Value += this.Life;
                    break;
                case "Attack":
                    PlayerData.Instance.Attack.Value += this.Attack;
                    break;
                case "Defend":
                    PlayerData.Instance.Defend.Value += this.Defend;
                    break;
                case "Level":
                    PlayerData.Instance.Level.Value += this.Level;
                    break;
                case "Experience":
                    PlayerData.Instance.Experience.Value += this.Experience;
                    break;
                case "Gold":
                    PlayerData.Instance.Gold.Value += this.Gold;
                    break;
                case "YellowKey":
                    PlayerData.Instance.YellowKey.Value += this.YellowKey;
                    break;
                case "RedKey":
                    PlayerData.Instance.RedKey.Value += this.RedKey;
                    break;
                case "PurpleKey":
                    PlayerData.Instance.PurpleKey.Value += this.PurpleKey;
                    break;
                default:
                    break;
            }
            gameObject.Hide();

        }

        public void OnSingletonInit()
        {
        }
    }

}