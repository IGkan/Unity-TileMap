/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using QFramework;

namespace Tower
{
	public partial class npc2_8Panel : UIElement
	{
		private void Start()
		{
            BtnAddAttack.onClick.AddListener(() =>
            {
                // 玩家经验需要大于等于此次消费
                if (Player.Instance.mPlayerData.Experience.Value >= Player.Instance.mPlayerData.ExperienceCharge.Value)
                {
                    Player.Instance.mPlayerData.Experience.Value -= Player.Instance.mPlayerData.ExperienceCharge.Value;
                    Player.Instance.mPlayerData.Level.Value += Player.Instance.mPlayerData.AddLevel.Value;
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