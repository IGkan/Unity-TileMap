/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Tower
{
	public partial class FloorPanel
	{
		[SerializeField] public UnityEngine.UI.Button BtnFloor;

		public void Clear()
		{
			BtnFloor = null;
		}

		public override string ComponentName
		{
			get { return "FloorPanel";}
		}
	}
}
