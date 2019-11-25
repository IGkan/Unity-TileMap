/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Tower
{
	public partial class TipPanel
	{
		[SerializeField] public UnityEngine.UI.Text MonsterTipText;

		public void Clear()
		{
			MonsterTipText = null;
		}

		public override string ComponentName
		{
			get { return "TipPanel";}
		}
	}
}
