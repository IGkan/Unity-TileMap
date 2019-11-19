/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Tower
{
	public partial class MenuPanel
	{
		[SerializeField] public UnityEngine.UI.Button BtnPeep;
		[SerializeField] public UnityEngine.UI.Button BtnSelectLevel;
		[SerializeField] public UnityEngine.UI.Button BtnSetting;
		[SerializeField] public UnityEngine.UI.Button BtnMusic;

		public void Clear()
		{
			BtnPeep = null;
			BtnSelectLevel = null;
			BtnSetting = null;
			BtnMusic = null;
		}

		public override string ComponentName
		{
			get { return "MenuPanel";}
		}
	}
}
