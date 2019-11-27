/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using UnityEngine.UI;
using QFramework;
using QF.Res;
using UniRx;
using UnityEngine;

namespace Tower
{
	public partial class MenuPanel : UIElement
	{
        //ResLoader mResLoader = ResLoader.Allocate();
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
               // Player.Instance.mPlayerData.CanPeepMonster.Value = !Player.Instance.mPlayerData.CanPeepMonster.Value; // �鿴��������
            });

            BtnSetting.onClick.AddListener(() =>  // ���ý��濪��
            {
<<<<<<< HEAD
                //Player.Instance.mPlayerData.SavePlayerData();
                UIMgr.OpenPanel<MyMotaUIHomePanel>();

=======
                PlayerData.Instance.SavePlayerData();
                //UIMgr.OpenPanel<MyMotaUIHomePanel>();
>>>>>>> 8207420c391999537d5f8dbc19fe02f937f6ba2d
            });

            // ѡ��
            Player.Instance.mPlayerData.CanSelectFloor.Subscribe(content =>
            {
                if (content)
                {
                    // �滻ͼ��
                    var sprite = Resources.Load<Sprite>("Sprites/SelectLevelOn");
                    BtnSelectLevel.GetComponent<Image>().sprite = sprite;
                }
                else
                {
                    var sprite = Resources.Load<Sprite>("Sprites/SelectLevelOff");
                    BtnSelectLevel.GetComponent<Image>().sprite = sprite;
                }
            }
            );

            // �鿴��������
            Player.Instance.mPlayerData.CanPeepMonster.Subscribe(content =>
            {
                if (content)
                {
                    //  // �滻ͼ��
                    var sprite = Resources.Load<Sprite>("Sprites/PeepMonsterOn");
                    BtnPeep.GetComponent<Image>().sprite = sprite;
                }
                else
                {
                    var sprite = Resources.Load<Sprite>("Sprites/PeepMonsterOff");
                    BtnPeep.GetComponent<Image>().sprite = sprite;
                }
            }
          );
            AudioManager.Instance.SoundOn.Subscribe(content =>
            {
                if (content)
                {
                    //var sprite = mResLoader.LoadSprite("MusicOn");
                    //BtnMusic.GetComponent<Image>().sprite = sprite;
                    var sprite = Resources.Load<Sprite>("Sprites/MusicOn");
                    BtnMusic.GetComponent<Image>().sprite = sprite;
                }
                else
                {
                    var sprite = Resources.Load<Sprite>("Sprites/MusicOff");
                    BtnMusic.GetComponent<Image>().sprite = sprite;
                }
            }
           );
        }

        public void OpenSelectLevelPanel()
        {
            if (Player.Instance.mPlayerData.CanSelectFloor.Value)
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

		//protected override void OnBeforeDestroy()
		//{
  //          mResLoader.Recycle2Cache();
  //          mResLoader = null;
		//}
	}
}