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
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (Player.Instance.mPlayerData.Gold.Value >= Player.Instance.mPlayerData.GoldCharge.Value)
                {
                    Player.Instance.mPlayerData.Gold.Value -= Player.Instance.mPlayerData.GoldCharge.Value;
                    Player.Instance.mPlayerData.Attack.Value += Player.Instance.mPlayerData.AddAttack.Value;
                }
            });
            BtnAddDefend.onClick.AddListener(() =>
            {
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (Player.Instance.mPlayerData.Gold.Value >= Player.Instance.mPlayerData.GoldCharge.Value)
                {
                    Player.Instance.mPlayerData.Gold.Value -= Player.Instance.mPlayerData.GoldCharge.Value;
                    Player.Instance.mPlayerData.Defend.Value += Player.Instance.mPlayerData.AddDefend.Value;
                }
            });
            BtnAddLife.onClick.AddListener(() =>
            {
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (Player.Instance.mPlayerData.Gold.Value >= Player.Instance.mPlayerData.GoldCharge.Value)
                {
                    Player.Instance.mPlayerData.Gold.Value -= Player.Instance.mPlayerData.GoldCharge.Value;
                    Player.Instance.mPlayerData.Life.Value += Player.Instance.mPlayerData.AddLife.Value;
                }
            });
            BtnAddPanelQuit.onClick.AddListener(() =>
            {
                Player.Instance.mCanMove = true; // ��������ҿ��ƶ�
                this.Hide();
            });
        }

        /// <summary>
        ///  ������չ����
        /// </summary>
        /// <param name="wealth"> ��һ����Ǿ���</param>
        /// <param name="wealthCharge">����ֵ</param>
        /// <param name="value">��Ҫ���ӵ����Ե�ǰֵ</param>
        /// <param name="addValue">��Ҫ���ӵ�ֵ</param>
        void ChargeExtend(int wealth, int wealthCharge, int value, int addValue)
        {

        }
        protected override void OnBeforeDestroy()
		{
		}
	}
}