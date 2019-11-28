/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using QFramework;

namespace Tower
{
	public partial class npc2_4Panel : UIElement
	{
        // Կ���̵�
		private void Start()
		{
            BtnAddAttack.onClick.AddListener(() =>
            {
                //ChargeExtend(PlayerData.Instance.Gold.Value, PlayerData.Instance.GoldCharge.Value, 
                //    PlayerData.Instance.Attack.Value, PlayerData.Instance.AddAttack.Value);
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.YellowKey.Value += PlayerData.Instance.AddYellowKey.Value;
                }
            });
            BtnAddDefend.onClick.AddListener(() =>
            {
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.RedKey.Value += PlayerData.Instance.AddRedKey.Value;
                }
            });
            BtnAddLife.onClick.AddListener(() =>
            {
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.PurpleKey.Value += PlayerData.Instance.AddPurpleKey.Value;
                }
            });
            BtnAddPanelQuit.onClick.AddListener(() =>
            {
                Player.Instance.mCanMove = true; // ��������ҿ��ƶ�

                this.Hide();
            });
        }

		protected override void OnBeforeDestroy()
		{
		}
	}
}