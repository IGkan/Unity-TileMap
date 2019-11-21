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
                    if (PlayerData.Instance.NewGame.Value)
                    {
                        UIMgr.GetPanel<MyMotaUIGamePanel>().GuidePanel.Show(); // �򿪽���
                        PlayerData.Instance.YellowKey.Value += 1;
                        PlayerData.Instance.RedKey.Value += 1;
                        PlayerData.Instance.PurpleKey.Value += 1;
                        PlayerData.Instance.NewGame.Value = false;
                        Player.Instance.mCanMove = false; //��������ֹ�ƶ�

                    }
                    break;
                case "npc2_0": // ��������̵�
                               // �򿪹������
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_0Panel.Show(); // �򿪹������
                    PlayerData.Instance.AddAttack.Value = 10;
                    PlayerData.Instance.AddDefend.Value = 10;
                    PlayerData.Instance.AddLife.Value = 100;
                    PlayerData.Instance.GoldCharge.Value = 100;
                    Player.Instance.mCanMove = false; //��������ֹ�ƶ�

                    break;

                case "npc2_4":  // ����Կ���̵�
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_4Panel.Show(); // �򿪹������
                    PlayerData.Instance.YellowKey.Value = 1;
                    PlayerData.Instance.RedKey.Value = 1;
                    PlayerData.Instance.PurpleKey.Value = 1;
                    PlayerData.Instance.GoldCharge.Value = 100;
                    Player.Instance.mCanMove = false; //��������ֹ�ƶ�

                    break;

                case "npc2_8": // ���������̵�,���ڹ���ȼ�
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_8Panel.Show(); // �򿪹������
                    PlayerData.Instance.AddLevel.Value = 1;
                    PlayerData.Instance.ExperienceCharge.Value = 100;
                    Player.Instance.mCanMove = false; //��������ֹ�ƶ�

                    break;
             
                case "npc2_12":  // �߼�����̵�
                    UIMgr.GetPanel<MyMotaUIGamePanel>().npc2_12Panel.Show(); // �򿪹������
                    PlayerData.Instance.AddAttack.Value = 30;
                    PlayerData.Instance.AddDefend.Value = 30;
                    PlayerData.Instance.AddLife.Value = 300;
                    PlayerData.Instance.GoldCharge.Value = 100;
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
