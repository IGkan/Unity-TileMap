namespace Tower
{
    using QF;
    using QF.Extensions;
    using QF.Res;
    using QFramework;
    using UnityEngine;
   
    public class MonsterBase:QMonoBehaviour
    {
        protected string mName;
        protected int mLevel;
        protected int mLife;
        protected int mAttack;
        protected int mDefend;
        protected int mExperience;
        protected int mGold;

        public override IManager Manager => UIManager.Instance;

        public MonsterBase(string _mName, int _mLevel, int _mLife, int _mAttack, int _mDefend, int _mExperience, int _mGold)
        {
            mName = _mName;
            mLevel = _mLevel;
            mLife = _mLife;
            mAttack = _mAttack;
            mDefend = _mDefend;
            mExperience = _mExperience;
            mGold = _mGold;
        }



        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {

        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {

        }
        /// <summary>
        /// ָ��ģʽ => PlayerData
        /// </summary>
        /// <param name="child"></param>
        /// <param name="ExecuteMode">0 => ֻ�ص��õ�Ԥ�ƶ������ɵ��˺���ִ�������߼�, 1 => �ص���ֱ������ PlayerData </param>
        /// <returns></returns>
        protected int Execute(MonsterBase child, int ExecuteMode = 0)
        {
            var playerData = PlayerData.Instance;
            int oneAttack = child.mAttack - playerData.Defend.Value; // ����һ�غ϶������ɵ��˺�
            int count = 0; // ����������ɵ����˺�
            while (child.mLife > 0)
            {
                if (playerData.Attack.Value - child.mDefend > 0) // ����ܶԹ�������˺�
                {
                    child.mLife -= (playerData.Attack.Value - child.mDefend);
                    if (child.mLife <= 0) // ��������
                    {
                       if(ExecuteMode == 1) gameObject.Hide();  //1 => �ص���ִ��,ֱ������ PlayerData
                        return count;
                    }
                }
                else
                {
                    Log.I("���Ʋ���������");
                    return count;
                }
                if (child.mAttack - playerData.Defend.Value > 0) // �����ܶ��������˺�
                {
                    count += oneAttack;
                    if (playerData.Life.Value <= 0) // �������
                    {
                        return count;
                    }
                }
                else
                {
                    Log.I("�����Ʋ�����ķ�����");
                }
            }
            return count;
        }
    }

}