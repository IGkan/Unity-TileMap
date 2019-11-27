namespace Tower
{
    using QF;
    using QF.Extensions;
    using QF.Res;
    using QFramework;
    using UniRx;
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

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {

        }
        /// <summary>
        /// 指令模式 => PlayerData
        /// </summary>
        /// <param name="child"></param>
        /// <param name="ExecuteMode">0 => 只回调得到预计对玩家造成的伤害不执行其他逻辑, 1 => 回调且直接作用 PlayerData </param>
        /// <returns></returns>
        protected int Execute(MonsterBase child)
        {
            var playerData = Player.Instance.mPlayerData;
            int oneAttack = child.mAttack - playerData.Defend.Value; // 怪物一回合对玩家造成的伤害
            int count = 0; // 怪物对玩家造成的总伤害
            int mChildLife = child.mLife;
            while (mChildLife > 0)
            {
                if (playerData.Attack.Value - child.mDefend > 0) // 玩家能对怪物造成伤害
                {
                    mChildLife -= (playerData.Attack.Value - child.mDefend);
                    if (mChildLife <= 0 && count < playerData.Life.Value) // 怪物死亡
                    {
                       gameObject.Hide();  //1 => 回调且执行,直接作用 PlayerData
                       //playerData.AddHideObjPos(gameObject.transform.localPosition);
                       return count;
                    }
                }
                else
                {
                    Log.I("你破不了它防御");
                    return count;
                }
                if (child.mAttack - playerData.Defend.Value > 0) // 怪物能对玩家造成伤害
                {
                    count += oneAttack;
                }
                else
                {
                    //Log.I("怪物破不了你的防御！");
                }
            }
            return count;
        }



        protected int ExpectDamaged(MonsterBase child,out string mTip)
        {
            var playerData = Player.Instance.mPlayerData;
            int oneAttack = child.mAttack - playerData.Defend.Value; // 怪物一回合对玩家造成的伤害
            int count = 0; // 怪物对玩家造成的总伤害
            int mChildLife = child.mLife;
            while (mChildLife > 0)
            {
                if (playerData.Attack.Value - child.mDefend > 0) // 玩家能对怪物造成伤害
                {
                    mChildLife -= (playerData.Attack.Value - child.mDefend);
                    if (mChildLife <= 0 && count < playerData.Life.Value) // 怪物死亡
                    {
                        mTip = "你可以战胜它";
                        return count;
                    }
                    else
                    {
                        mTip = "你无法战胜它";
                        return count;
                    }
                }
                else
                {
                    mTip = "你破不了它防御";
                    return count;
                }
                if (child.mAttack - playerData.Defend.Value > 0) // 怪物能对玩家造成伤害
                {
                    count += oneAttack;
                }
                else
                {
                    mTip = "怪物破不了你的防御！";
                    return count;
                }
            }
            mTip = "怪物能对你造成伤害！";
            return count;
        }
    }

}