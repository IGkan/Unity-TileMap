namespace Tower
{
    using QF;
    using QF.Action;
    using QFramework;
    using UnityEngine;

    public class Monster : MonsterBase,ISingleton
    {
        public static Monster Instance
        {
            get { return MonoSingletonProperty<Monster>.Instance; }
        }
        public string Name;
        public int Level;
        public int Life;
        public int Attack;
        public int Defend;
        public int Experience;
        public int Gold; 

        public MonsterBase monster;
        private void Reset()
        {
            Name = transform.name;
        }
        private void Start()
        {
            monster = new Monster(Name,Level, Life, Attack, Defend, Experience, Gold);
            m_TipPanel = UIMgr.GetPanel<MyMotaUIGamePanel>().TipPanel;
        }
        public Monster(string _mName, int _mLevel, int _mLife, int _mAttack, int _mDefend, int _mExperience, int _mGold) : base(_mName, _mLevel, _mLife, _mAttack, _mDefend, _mExperience, _mGold)
        {

        }

        /// <summary>
        /// ִ�иɼ��߼�
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public  bool MonsterExecute(Collider2D other)
        {
            var playerData = Player.Instance.mPlayerData;
            if (playerData.Attack.Value > Defend)
            {
                int ExpectedCount = GetExpectDamage();
                Debug.Log(ExpectedCount);
                if (playerData.Life.Value > ExpectedCount)
                {
                    int count = Execute(monster);//�ص���ִ��,ֱ������ PlayerData, count ����Ԥ�ƶ������ɵ��˺�
                    playerData.Life.Value -= count;
                    playerData.Experience.Value += Experience;
                    playerData.Gold.Value += Gold;
                    if (other.gameObject.name == "enemy12_8") // Boss ,��ƽṹ������Ż�
                    {
                        UIMgr.OpenPanel<MyMotaUIEndPanel>();
                        UIMgr.ClosePanel<MyMotaUIGamePanel>();
                    }
                    return true;
                }
            }
                return false;
            }


        TipPanel m_TipPanel;
        /// <summary>
        /// ���ù�������UI ��ʾ
        /// </summary>
        public void MonsterDisplay()
        {
            string mTip;
            int ExpectDamagedInt = ExpectDamaged(monster, out mTip);
            this.Sequence()
                .Event(() => m_TipPanel.Show())
                .Event(() => m_TipPanel.MonsterTipText.text = "<b><color=red><size=50>" + mTip + "</size></color></b>" + "\n" + 
                                                                    "���﹥��ֵ: " + Attack + "\n" +
                                                                      "�������ֵ: " +Defend +"\n" +
                                                                            "��������ֵ: " + Life+"\n" +
                                                                            "��ɱ�ͽ�: " + Gold + "\n" +
                                                                            "��ɱ����: " + Experience + "\n" +
                                                                               "���ｫ������� " + "<size=70><color=red><i>" +ExpectDamagedInt +"</i></color></size>"+ " �˺�")
                .Begin();
        }

         
        /// <summary>
        /// ����Ԥ�ƶ������ɵ��˺�,ֻ�õ�ֵ��ִ���߼�
        /// </summary>
        /// <returns></returns>
        public int GetExpectDamage()
        {
            return ExpectDamaged(monster, out string mTip);
        }

        public void OnSingletonInit()
        {
        }
    }

}