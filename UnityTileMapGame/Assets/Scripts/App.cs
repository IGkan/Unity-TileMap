using QF.Res;
using QFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tower
{
    public class App : MonoBehaviour
    {
        private void Awake()
        {
            ResMgr.Init();
            UIMgr.SetResolution(1920, 1080, 0);
        }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.5f);
            UIMgr.OpenPanel<UIHomePanel>();
        }
    }
}