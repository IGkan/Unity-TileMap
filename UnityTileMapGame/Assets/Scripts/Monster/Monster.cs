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
        /// 执行干架逻辑
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
                    int count = Execute(monster);//回调且执行,直接作用 PlayerData, count 怪物预计对玩家造成的伤害
                    playerData.Life.Value -= count;
                    playerData.Experience.Value += Experience;
                    playerData.Gold.Value += Gold;
                    if (other.gameObject.name == "enemy11_4") // Boss ,设计结构后面待优化
                    {
                        UIMgr.OpenPanel<MyMotaUIEndPanel>();
                    }
                    return true;
                }
               
            }
                //GameObject.Find("tipText").GetComponent<Text>().text = "您打不过它!请继续提升战斗力!";
                return false;
            }


        GameObject TipObj;
        /// <summary>
        /// 调用怪物属性UI 显示
        /// </summary>
        public void MonsterDisplay()
        {
            if (TipObj.activeSelf) return;
            this.Sequence()
                .Event(() => TipObj.gameObject.SetActive(true))
                .Event(() => UIMgr.GetPanel<MyMotaUIGamePanel>().MonsterTipText.text = "我们是" + " \n" + " 好人" + "\n" + "你吗个打几把")
                .Delay(1f)
                 .Event(() => TipObj.SetActive(false))
                .Begin();

        }

         
        /// <summary>
        /// 怪物预计对玩家造成的伤害,只得到值不执行逻辑
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