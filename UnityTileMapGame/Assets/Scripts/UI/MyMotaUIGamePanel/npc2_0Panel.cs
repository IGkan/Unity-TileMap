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
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.Attack.Value += PlayerData.Instance.AddAttack.Value;
                }
            });
            BtnAddDefend.onClick.AddListener(() =>
            {
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.Defend.Value += PlayerData.Instance.AddDefend.Value;
                }
            });
            BtnAddLife.onClick.AddListener(() =>
            {
                // ��ҽ����Ҫ���ڵ��ڴ˴�����
                if (PlayerData.Instance.Gold.Value >= PlayerData.Instance.GoldCharge.Value)
                {
                    PlayerData.Instance.Gold.Value -= PlayerData.Instance.GoldCharge.Value;
                    PlayerData.Instance.Life.Value += PlayerData.Instance.AddLife.Value;
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