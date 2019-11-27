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
                case "npc1_12": // ������������
                    if (Player.Instance.mPlayerData.NewGame.Value)
                    {
                        UIMgr.GetPanel<MyMotaUIGamePanel>().GuidePanel.Show(); // �򿪽���
                        Player.Instance.mPlayerData.YellowKey.Value += 1;
                        Player.Instance.mPlayerData.RedKey.Value += 1;
                        Player.Instance.mPlayerData.PurpleKey.Value += 1;
                        Player.Instance.mPlayerData.NewGame.Value = false;
                        Player.Instance.mCanMove = false; //��������ֹ�ƶ�

                    }
                    break;
                case "npc2_0": // ��������̵�
                               // �򿪹������
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_0Panel.Show(); // �򿪹������
                    Player.Instance.mPlayerData.AddAttack.Value = 10;
                    Player.Instance.mPlayerData.AddDefend.Value = 10;
                    Player.Instance.mPlayerData.AddLife.Value = 100;
                    Player.Instance.mPlayerData.GoldCharge.Value = 100;
                    Player.Instance.mCanMove = false; //��������ֹ�ƶ�

                    break;

                case "npc2_4":  // ����Կ���̵�
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_4Panel.Show(); // �򿪹������
                    Player.Instance.mPlayerData.YellowKey.Value = 1;
                    Player.Instance.mPlayerData.RedKey.Value = 1;
                    Player.Instance.mPlayerData.PurpleKey.Value = 1;
                    Player.Instance.mPlayerData.GoldCharge.Value = 100;
                    Player.Instance.mCanMove = false; //��������ֹ�ƶ�

                    break;

                case "npc2_8": // ���������̵�,���ڹ���ȼ�
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_8Panel.Show(); // �򿪹������
                    Player.Instance.mPlayerData.AddLevel.Value = 1;
                    Player.Instance.mPlayerData.ExperienceCharge.Value = 100;
                    Player.Instance.mCanMove = false; //��������ֹ�ƶ�

                    break;
             
                case "npc2_12":  // �߼�����̵�
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_12Panel.Show(); // �򿪹������
                    Player.Instance.mPlayerData.AddAttack.Value = 30;
                    Player.Instance.mPlayerData.AddDefend.Value = 30;
                    Player.Instance.mPlayerData.AddLife.Value = 300;
                    Player.Instance.mPlayerData.GoldCharge.Value = 100;
                    Player.Instance.mCanMove = false; //��������ֹ�ƶ�
                    break;

                case "npc-02_12": // С����

                    break;
                default:
                    break;
            }
        }
    }
}
