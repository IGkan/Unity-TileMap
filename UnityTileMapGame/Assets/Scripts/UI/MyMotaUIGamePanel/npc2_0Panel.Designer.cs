﻿/****************************************************************************
 * 2019.11 DESKTOP-SF453R4
 ****************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using QFramework;

namespace Tower
{
	public partial class npc2_0Panel
	{
		[SerializeField] public UnityEngine.UI.Text ChargeText;
		[SerializeField] public UnityEngine.UI.Button BtnAddAttack;
		[SerializeField] public UnityEngine.UI.Button BtnAddDefend;
		[SerializeField] public UnityEngine.UI.Button BtnAddLife;
		[SerializeField] public UnityEngine.UI.Button BtnAddPanelQuit;

		public void Clear()
		{
			ChargeText = null;
			BtnAddAttack = null;
			BtnAddDefend = null;
			BtnAddLife = null;
			BtnAddPanelQuit = null;
		}

		public override string ComponentName
		{
			get { return "npc2_0Panel";}
		}
	}
}