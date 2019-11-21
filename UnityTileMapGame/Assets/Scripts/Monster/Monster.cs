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
            TipObj = UIMgr.GetPanel<MyMotaUIGamePanel>().TipPanel.gameObject;
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
            var playerData = PlayerData.Instance;
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
                    if (other.gameObject.name == "enemy11_4") // Boss ,��ƽṹ������Ż�
                    {
                        UIMgr.OpenPanel<MyMotaUIEndPanel>();
                    }
                    return true;
                }
               
            }
                //GameObject.Find("tipText").GetComponent<Text>().text = "���򲻹���!���������ս����!";
                return false;
            }


        GameObject TipObj;
        /// <summary>
        /// ���ù�������UI ��ʾ
        /// </summary>
        public void MonsterDisplay()
        {
            if (TipObj.activeSelf) return;
            this.Sequence()
                .Event(() => TipObj.gameObject.SetActive(true))
                .Event(() => UIMgr.GetPanel<MyMotaUIGamePanel>().MonsterTipText.text = "������" + " \n" + " ����" + "\n" + "������򼸰�")
                .Delay(1f)
                 .Event(() => TipObj.SetActive(false))
                .Begin();

        }

         
        /// <summary>
        /// ����Ԥ�ƶ������ɵ��˺�,ֻ�õ�ֵ��ִ���߼�
        /// </summary>
        /// <returns></returns>
        public int GetExpectDamage()
        {
            return ExpectDamaged(monster);
        }

        public void OnSingletonInit()
        {
        }
    }

}