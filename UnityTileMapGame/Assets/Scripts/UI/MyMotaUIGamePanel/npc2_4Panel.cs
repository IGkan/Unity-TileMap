/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using QFramework;

namespace Tower
{
	public partial class npc2_4Panel : UIElement
	{
        // 钥匙商店
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
                    PlayerData.Instance.YellowKey.Value += PlayerData.Instance.AddYellowKey.Value;
                }
            });
            BtnAddDefend.onClick.AddListener(() =>
            {
                // 玩家金币需要大于等于此次消费
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.RedKey.Value += PlayerData.Instance.AddRedKey.Value;
                }
            });
            BtnAddLife.onClick.AddListener(() =>
            {
                // 玩家金币需要大于等于此次消费
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.PurpleKey.Value += PlayerData.Instance.AddPurpleKey.Value;
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