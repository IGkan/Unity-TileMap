/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using QFramework;

namespace Tower
{
	public partial class npc2_12Panel : UIElement
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

		protected override void OnBeforeDestroy()
		{
		}
	}
}