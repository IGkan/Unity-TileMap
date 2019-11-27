/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using QFramework;
namespace Tower
{
	public partial class npc2_0Panel : UIElement
	{
		private void Start()
		{
            BtnAddAttack.onClick.AddListener(() =>
            {
                //ChargeExtend(Player.Instance.mPlayerData.Gold.Value, Player.Instance.mPlayerData.GoldCharge.Value, 
                //    Player.Instance.mPlayerData.Attack.Value, Player.Instance.mPlayerData.AddAttack.Value);
                // 玩家金币需要大于等于此次消费
                if (Player.Instance.mPlayerData.Gold.Value >= Player.Instance.mPlayerData.GoldCharge.Value)
                {
                    Player.Instance.mPlayerData.Gold.Value -= Player.Instance.mPlayerData.GoldCharge.Value;
                    Player.Instance.mPlayerData.Attack.Value += Player.Instance.mPlayerData.AddAttack.Value;
                }
            });
            BtnAddDefend.onClick.AddListener(() =>
            {
                // 玩家金币需要大于等于此次消费
                if (Player.Instance.mPlayerData.Gold.Value >= Player.Instance.mPlayerData.GoldCharge.Value)
                {
                    Player.Instance.mPlayerData.Gold.Value -= Player.Instance.mPlayerData.GoldCharge.Value;
                    Player.Instance.mPlayerData.Defend.Value += Player.Instance.mPlayerData.AddDefend.Value;
                }
            });
            BtnAddLife.onClick.AddListener(() =>
            {
                // 玩家金币需要大于等于此次消费
                if (Player.Instance.mPlayerData.Gold.Value >= Player.Instance.mPlayerData.GoldCharge.Value)
                {
                    Player.Instance.mPlayerData.Gold.Value -= Player.Instance.mPlayerData.GoldCharge.Value;
                    Player.Instance.mPlayerData.Life.Value += Player.Instance.mPlayerData.AddLife.Value;
                }
            });
            BtnAddPanelQuit.onClick.AddListener(() =>
            {
                Player.Instance.mCanMove = true; // 重新让玩家可移动
                this.Hide();
            });
        }

        /// <summary>
        ///  消费扩展方法
        /// </summary>
        /// <param name="wealth"> 金币或者是经验</param>
        /// <param name="wealthCharge">消费值</param>
        /// <param name="value">需要增加的属性当前值</param>
        /// <param name="addValue">需要增加的值</param>
        void ChargeExtend(int wealth, int wealthCharge, int value, int addValue)
        {

        }
        protected override void OnBeforeDestroy()
		{
		}
	}
}