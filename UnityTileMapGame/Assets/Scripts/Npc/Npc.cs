namespace Tower
{
    using QF.Extensions;
    using QF.Res;
    using QFramework;
    using UnityEngine;

    public class Npc : QMonoBehaviour
    {
        public override IManager Manager => UIManager.Instance;

        public void NpcExecute(string NpcName)
        {
            Player.Instance.ChangeMovingState();
            SendMsg(new AudioSoundMsg("talk"));

            switch (NpcName)
            {
                case "npc1_12": // 精灵引导界面
                    if (Player.Instance.mPlayerData.NewGame.Value)
                    {
                        UIMgr.GetPanel<MyMotaUIGamePanel>().GuidePanel.Show(); // 打开界面
                        Player.Instance.mPlayerData.YellowKey.Value += 1;
                        Player.Instance.mPlayerData.RedKey.Value += 1;
                        Player.Instance.mPlayerData.PurpleKey.Value += 1;
                        Player.Instance.mPlayerData.NewGame.Value = false;
                        Player.Instance.mCanMove = false; //聊天界面禁止移动

                    }
                    break;
                case "npc2_0": // 初级金币商店
                               // 打开购买界面
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_0Panel.Show(); // 打开购买界面
                    Player.Instance.mPlayerData.AddAttack.Value = 10;
                    Player.Instance.mPlayerData.AddDefend.Value = 10;
                    Player.Instance.mPlayerData.AddLife.Value = 100;
                    Player.Instance.mPlayerData.GoldCharge.Value = 100;
                    Player.Instance.mCanMove = false; //聊天界面禁止移动

                    break;

                case "npc2_4":  // 初级钥匙商店
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_4Panel.Show(); // 打开购买界面
                    Player.Instance.mPlayerData.YellowKey.Value = 1;
                    Player.Instance.mPlayerData.RedKey.Value = 1;
                    Player.Instance.mPlayerData.PurpleKey.Value = 1;
                    Player.Instance.mPlayerData.GoldCharge.Value = 100;
                    Player.Instance.mCanMove = false; //聊天界面禁止移动

                    break;

                case "npc2_8": // 初级经验商店,用于购买等级
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_8Panel.Show(); // 打开购买界面
                    Player.Instance.mPlayerData.AddLevel.Value = 1;
                    Player.Instance.mPlayerData.ExperienceCharge.Value = 100;
                    Player.Instance.mCanMove = false; //聊天界面禁止移动

                    break;
             
                case "npc2_12":  // 高级金币商店
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_12Panel.Show(); // 打开购买界面
                    Player.Instance.mPlayerData.AddAttack.Value = 30;
                    Player.Instance.mPlayerData.AddDefend.Value = 30;
                    Player.Instance.mPlayerData.AddLife.Value = 300;
                    Player.Instance.mPlayerData.GoldCharge.Value = 100;
                    Player.Instance.mCanMove = false; //聊天界面禁止移动
                    break;

                case "npc-02_12": // 小公主

                    break;
                default:
                    break;
            }
        }
    }
}
