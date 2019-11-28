namespace Tower
{
    using QF;
    using UnityEngine;
    using QF.Action;
    using QFramework;

    public class TipMsg : MonoBehaviour, ISingleton
    {
        public static TipMsg Instance
        {
            get { return MonoSingletonProperty<TipMsg>.Instance; }
        }
        public void OnSingletonInit()
        {
        }

        public void DipslayInfo(string mInfo)
        {
            this.Sequence()
                           .Event(() => UIMgr.GetPanel<MyMotaUITipPanel>().TipText.text = mInfo)
                           .Delay(1f)
                           .Event(() => UIMgr.GetPanel<MyMotaUITipPanel>().TipText.text = "")
                           .Begin();
        }
    }

}