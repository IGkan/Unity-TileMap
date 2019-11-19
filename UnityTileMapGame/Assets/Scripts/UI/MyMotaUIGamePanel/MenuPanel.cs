/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using QF.Res;

namespace Tower
{
	public partial class MenuPanel : UIElement
	{
        ResLoader mResLoader = ResLoader.Allocate();
		private void Awake()
		{
            BtnMusic.onClick.AddListener(() =>
            {
                PlayAudioSwitch();
            });
		}
        public void PlayAudioSwitch()
        {
            //Log.I(!QF.Res.AudioManager.Instance.SoundOn.Value);
            if (!QF.Res.AudioManager.Instance.SoundOn.Value)
            {
                SendMsg(new AudioMsgWithBool((ushort)AudioEvent.MusicSwitch, true));
                SendMsg(new AudioMsgWithBool((ushort)AudioEvent.SoundSwitch, true));
                SendMsg(new AudioMusicMsg("bg", true));
                var sprite = mResLoader.LoadSprite("MusicOn");
                BtnMusic.GetComponent<Image>().sprite = sprite;
            }
            else
            {
                SendMsg(new AudioMsgWithBool((ushort)AudioEvent.MusicSwitch, false));
                SendMsg(new AudioMsgWithBool((ushort)AudioEvent.SoundSwitch, false));
                SendMsg(new AudioMusicMsg("bg", false));
                var sprite = mResLoader.LoadSprite("MusicOff");
                BtnMusic.GetComponent<Image>().sprite = sprite;
            }
        }

		protected override void OnBeforeDestroy()
		{
            mResLoader = null;
            mResLoader.Recycle2Cache();
		}
	}
}