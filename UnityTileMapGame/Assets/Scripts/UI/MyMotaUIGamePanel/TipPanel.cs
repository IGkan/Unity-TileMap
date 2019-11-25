/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QFramework;
using System.Collections;
using QF.Action;

namespace Tower
{
	public partial class TipPanel : UIElement
	{
		private void Awake()
		{
		}

        protected override void OnShow()
        {
            this.Sequence()
                .Delay(1f)
                .Event(() => this.Hide())
                .Begin();
        }
        protected override void OnBeforeDestroy()
		{
		}
	}
}