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
                //ChargeExtend(PlayerData.Instance.Gold.Value, PlayerData.Instance.GoldCharge.Value, 
                //    PlayerData.Instance.Attack.Value, PlayerData.Instance.AddAttack.Value);
                // 玩家金币需要大于等于此次消费
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.Attack.Value += PlayerData.Instance.AddAttack.Value;
                }
            });
            BtnAddDefend.onClick.AddListener(() =>
            {
                // 玩家金币需要大于等于此次消费
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.Defend.Value += PlayerData.Instance.AddDefend.Value;
                }
            });
            BtnAddLife.onClick.AddListener(() =>
            {
                // 玩家金币需要大于等于此次消费
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.Life.Value += PlayerData.Instance.AddLife.Value;
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