/****************************************************************************
 * 2019.11 PS2019HINRKUYZ
 ****************************************************************************/

using QFramework;
using QF.Extensions;
using System;
using UnityEngine.UI;

namespace Tower
{
    public partial class FloorPanel : UIElement
    {
        private void Awake()
        {
            for (int i = 0; i < PlayerData.Instance.MaxFloor.Value; i++)
            {
                BtnFloor.Instantiate()
                    .Parent(this)
                    .Name((i + 1).ToString())
                    .LocalIdentity()
                    .ApplySelfTo(self =>
                    {
                        self.onClick.AddListener(() =>
                        {
                            Stair.ComeUp(Convert.ToInt32(self.name));
                        });
                    })
                      .ApplySelfTo(self =>
                      {
                          self.GetComponentInChildren<Text>().text = "ตฺ " + self.name + "นุ";
                      })
                    .Show();
            }
        }

        protected override void OnBeforeDestroy()
        {
        }
    }
}