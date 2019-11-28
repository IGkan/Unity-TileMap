namespace Tower
{
    using QF.Res;
    using QFramework;
    using UnityEngine;

    public class MotaApp : MonoBehaviour
    {
        private void Awake()
        {
            ResKit.Init();
            UIMgr.SetResolution(1080, 2244, 0);
        }
        private void Start()
        {
<<<<<<< HEAD

            UIMgr.OpenPanel<MyMotaUIHomePanel>(new MyMotaUIHomePanelData()
            {
                Model = mModel
            }) ;
=======
            UIMgr.OpenPanel<MyMotaUIHomePanel>();
>>>>>>> 8207420c391999537d5f8dbc19fe02f937f6ba2d
=======
            UIMgr.OpenPanel<MyMotaUIHomePanel>();
        }

        private void OnDestroy()
        {
            PlayerData.Instance.SavePlayerData();
        }
        private void OnApplicationQuit()
        {
            PlayerData.Instance.SavePlayerData();
>>>>>>> parent of b1f25529... 11.27
        }
    }

}