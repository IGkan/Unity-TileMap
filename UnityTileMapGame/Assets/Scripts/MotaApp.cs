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
<<<<<<< HEAD
=======
            
>>>>>>> parent of 9e6f122f... 28.2
        }
        private void Start()
        {
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> parent of 9e6f122f... 28.2
            UIMgr.OpenPanel<MyMotaUIHomePanel>(new MyMotaUIHomePanelData()
            {
                Model = mModel
            }) ;
=======
            UIMgr.OpenPanel<MyMotaUIHomePanel>();
>>>>>>> 8207420c391999537d5f8dbc19fe02f937f6ba2d
        }
    }

}