namespace Tower
{
    using QF;
    using QF.Extensions;
    using QF.Res;
    using QFramework;
    using UnityEngine;
    using UnityEngine.UI;

    public class Monster : MonsterBase
    {
        public string Name;
        public int Level;
        public int Life;
        public int Attack;
        public int Defend;
        public int Experience;
        public int Gold; 

        MonsterBase monster;
        private void Reset()
        {
            Name = transform.name;
        }
        private void Start()
        {
            monster = new Monster(Name,Level, Life, Attack, Defend, Experience, Gold);
        }
        public Monster(string _mName, int _mLevel, int _mLife, int _mAttack, int _mDefend, int _mExperience, int _mGold) : base(_mName, _mLevel, _mLife, _mAttack, _mDefend, _mExperience, _mGold)
        {

        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            var playerData = PlayerData.Instance;
            if (playerData.Attack.Value > Defend)
            {
                this.SendMsg(new AudioSoundMsg("fight"));
                int count = Execute(monster, 1);// 1 => �ص���ִ��,ֱ������ PlayerData, count ����Ԥ�ƶ������ɵ��˺�
                playerData.Life.Value -= count;
                playerData.Experience.Value += Experience;
                playerData.Gold.Value += Gold;
            }
            else
            {
                GameObject.Find("tipText").GetComponent<Text>().text = "���򲻹���!���������ս����!";
            }
        }

        protected override void OnTriggerExit2D(Collider2D collision)
        {
            GameObject.Find("tipText").GetComponent<Text>().text = "";
        }
        /// <summary>
        /// ����Ԥ�ƶ������ɵ��˺�,ֻ�õ�ֵ��ִ���߼�
        /// </summary>
        /// <returns></returns>
        public int GetDamage()
        {
            return Execute(monster);
        }
    }

}