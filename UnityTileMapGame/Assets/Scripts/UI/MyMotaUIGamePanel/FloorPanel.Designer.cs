/****************************************************************************
 * 2019.11 PS2019HINRKUYZ
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
