/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using UnityEngine.UI;
using QFramework;
using QF.Res;
using UniRx;

namespace Tower
{
	public partial class MenuPanel : UIElement
	{
        ResLoader mResLoader = ResLoader.Allocate();
		private void Start()
		{
            BtnMusic.onClick.AddListener(() =>
            {
                PlayAudioSwitch(); // ��������
            });

            BtnSelectLevel.onClick.AddListener(() =>
            {
                OpenSelectLevelPanel(); //ѡ��ؿ�
            });

            BtnPeep.onClick.AddListener(() =>  // �������Կ���
            {
               // PlayerData.Instance.CanPeepMonster.Value = !PlayerData.Instance.CanPeepMonster.Value; // �鿴��������
            });

            BtnSetting.onClick.AddListener(() =>  // ���ý��濪��
            {
                UIMgr.OpenPanel<MyMotaUIHomePanel>();
                PlayerData.Instance.SavePlayerData();
            });

            // ѡ��
            PlayerData.Instance.CanSelectFloor.Subscribe(content =>
            {
                if (content)
                {
                    // �滻ͼ��
                    var sprite = mResLoader.LoadSprite("SelectLevelOn");
                    BtnSelectLevel.GetComponent<Image>().sprite = sprite;
                  
                }
                else
                {
                    var sprite = mResLoader.LoadSprite("SelectLevelOff");
                    BtnSelectLevel.GetComponent<Image>().sprite = sprite;
                }
            }
            );

            // �鿴��������
            PlayerData.Instance.CanPeepMonster.Subscribe(content =>
            {
                if (content)
                {
                    // �滻ͼ��
                    var sprite = mResLoader.LoadSprite("PeepMonsterOn");
                    BtnPeep.GetComponent<Image>().sprite = sprite;

                }
                else
                {
                    var sprite = mResLoader.LoadSprite("PeepMonsterOff");
                    BtnPeep.GetComponent<Image>().sprite = sprite;
                }
            }
          );
            AudioManager.Instance.SoundOn.Subscribe(content =>
            {
                if (content)
                {
                    var sprite = mResLoader.LoadSprite("MusicOn");
                    BtnMusic.GetComponent<Image>().sprite = sprite;

                }
                else
                {
                    var sprite = mResLoader.LoadSprite("MusicOff");
                    BtnMusic.GetComponent<Image>().sprite = sprite;
                }
            }
           );
        }

        public void OpenSelectLevelPanel()
        {
            if (PlayerData.Instance.CanSelectFloor.Value)
            {
                if (UIMgr.GetPanel<MyMotaUIGamePanel>().FloorPanel.isActiveAndEnabled)
                {
                    // �رչؿ����
                    UIMgr.GetPanel<MyMotaUIGamePanel>().FloorPanel.gameObject.SetActive(false);
                    Player.Instance.mCanMove = true;
                }
                else
                {
                    // �򿪹ؿ����
                    UIMgr.GetPanel<MyMotaUIGamePanel>().FloorPanel.gameObject.SetActive(true);
                    Player.Instance.mCanMove = false;
                }
            }
        }
        public void PlayAudioSwitch()
        {
            if (!QF.Res.AudioManager.Instance.SoundOn.Value)
            {
                SendMsg(new AudioMsgWithBool((ushort)AudioEvent.MusicSwitch, true));
                SendMsg(new AudioMsgWithBool((ushort)AudioEvent.SoundSwitch, true));
                SendMsg(new AudioMusicMsg("bg", true));
            }
            else
            {
                SendMsg(new AudioMsgWithBool((ushort)AudioEvent.MusicSwitch, false));
                SendMsg(new AudioMsgWithBool((ushort)AudioEvent.SoundSwitch, false));
                SendMsg(new AudioMusicMsg("bg", false));
            }
        }

		protected override void OnBeforeDestroy()
		{
            mResLoader.Recycle2Cache();
            mResLoader = null;
		}
	}
}