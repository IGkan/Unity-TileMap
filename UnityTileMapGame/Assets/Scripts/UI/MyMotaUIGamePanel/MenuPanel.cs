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
                PlayAudioSwitch(); // 声音开关
            });

            BtnSelectLevel.onClick.AddListener(() =>
            {
                OpenSelectLevelPanel(); //选择关卡
            });

            BtnPeep.onClick.AddListener(() =>
            {
                // 查看怪物属性
            });

            BtnSetting.onClick.AddListener(() =>
            {
                // 设置界面
            });


            PlayerData.Instance.CanSelectFloor.Subscribe(content =>
            {
                if (content)
                {
                    // 替换图标
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
                // 打开关卡面板
                UIMgr.GetPanel<MyMotaUIGamePanel>().FloorPanel.gameObject.SetActive(UIMgr.GetPanel<MyMotaUIGamePanel>().FloorPanel.isActiveAndEnabled ? false : true);
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