
namespace Tower
{
    using QF.Res;
    using QFramework;
    using System;
    using UnityEngine;


    public class MyMotaUIHomePanelData : QFramework.UIPanelData
    {
        public PlayerData Model = new PlayerData ();
        
    }

    public partial class MyMotaUIHomePanel : QFramework.UIPanel
    {

        protected override void ProcessMsg(int eventId, QFramework.QMsg msg)
        {
            throw new System.NotImplementedException();
        }

        protected override void OnInit(QFramework.IUIData uiData)
        {
            mData = uiData as MyMotaUIHomePanelData ?? new MyMotaUIHomePanelData();

            SendMsg(new AudioMsgWithBool((ushort)AudioEvent.MusicSwitch, true));
            SendMsg(new AudioMusicMsg("start"));

        }

        public float MoveSpeed = 0.2f;
        protected override void RegisterUIEvent()
        {
            SpeedSlider.onValueChanged.AddListener((value) =>
            {
                 float pencent = (value - 1) / (3 - 1);
                 MoveSpeed = Convert.ToSingle(0.3 - 0.2 * pencent);
                 mData.Model.MoveSpeed.Value = MoveSpeed;
            });
            BtnStart.onClick.AddListener(() =>
            {
                if (transform.parent.childCount == 2)
                {
                    GameObject.Find("GameScenePrefab(Clone)").GetComponent<GameScenePrefab>().SetActiveAll();
                    Player.Instance.mPlayerData.InitPlayerData();
                }
                if (transform.parent.childCount == 1)
                {

                    UIMgr.OpenPanel<MyMotaUIGamePanel>(new MyMotaUIHomePanelData()
                    {
                        Model = mData.Model
                    }) ;
                    mData.Model.InitPlayerData();

                }
                CloseSelf();
                SendMsg(new AudioMusicMsg("bg"));
            });

            BtnSave.onClick.AddListener(()=> {

                if (transform.parent.childCount == 2)
                {
                    Player.Instance.mPlayerData.SavePlayerData();
                    TipMsg.Instance.DipslayInfo("数据保存成功");
                }
            });
            BtnReload.onClick.AddListener(() =>
            {
               mData.Model = mData.Model.LoadPlayerData();

                // 如果玩家第一次启动游戏 需要重新加载数据
                if (transform.parent.childCount == 1)
                {
                    UIMgr.OpenPanel<MyMotaUIGamePanel>(new MyMotaUIGamePanelData()
                    {
                        Model = mData.Model
                    });
                    mData.Model.CurrntFloor.Value = 1;
                    Player.Instance.mPlayerData.LoadTileData(); // 保存瓦片数据
                }

                // 这里可能判断 MyMotaUIGamePanel 是否已打开
                // 判断以前有没有打开过游戏 如果没有打开过游戏初始化一下数据
                if (mData.Model.NewGame.Value)
                {
                    mData.Model.InitPlayerData();
                }
                CloseSelf();
                SendMsg(new AudioMusicMsg("bg"));

            });
            BtnSetting.onClick.AddListener(() =>
            {
                if (SettingPanel.gameObject.activeSelf)
                {
                    SettingPanel.gameObject.SetActive(false);
                }
                else
                {
                    AboutPanel.gameObject.SetActive(false);
                    SettingPanel.gameObject.SetActive(true);

                }

            });
            BtnAbout.onClick.AddListener(() =>
            {
                if (AboutPanel.gameObject.activeSelf)
                {
                    AboutPanel.gameObject.SetActive(false);
                }
                else
                {
                    SettingPanel.gameObject.SetActive(false);
                    AboutPanel.gameObject.SetActive(true);
                }
                
            });
            BtnQuit.onClick.AddListener(() =>
            {
                Application.Quit();
            });

        }
        protected override void OnOpen(QFramework.IUIData uiData)
        {
        }

        protected override void OnShow()
        {
           MoveSpeed = PlayerPrefs.GetFloat("MoveSpeed", 0.2f);
            float pencent = Convert.ToSingle((0.3 - MoveSpeed) / 0.2);
            SpeedSlider.value = 1 + 2 * pencent;
        }

        protected override void OnHide()
        {
        }

        protected override void OnClose()
        {
            PlayerPrefs.SetFloat("MoveSpeed",MoveSpeed);
            Player.Instance.mPlayerData.MoveSpeed.Value = MoveSpeed;
        }


    }
}
