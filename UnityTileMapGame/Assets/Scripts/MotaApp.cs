namespace Tower
{
    using QF.Res;
    using QFramework;
    using UnityEngine;

    public class MotaApp : MonoBehaviour
    {
        public PlayerData mModel;
        private void Awake()
        {
            ResKit.Init();
            UIMgr.SetResolution(1080, 2244, 0);
            mModel = new PlayerData();
        }
        private void Start()
        {
            UIMgr.OpenPanel<MyMotaUIHomePanel>(new MyMotaUIHomePanelData()
            {
                Model = mModel
            });
            UIMgr.OpenPanel<MyMotaUITipPanel>(UILevel.PopUI);
        }

    }
}