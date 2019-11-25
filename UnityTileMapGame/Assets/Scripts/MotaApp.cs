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
            UIMgr.OpenPanel<MyMotaUIHomePanel>();
        }

        private void OnDestroy()
        {
            PlayerData.Instance.SavePlayerData();
        }
        private void OnApplicationQuit()
        {
            PlayerData.Instance.SavePlayerData();
        }
    }

}