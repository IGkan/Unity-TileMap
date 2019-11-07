using QF;
using UniRx;
using UnityEngine;
using QF.Extensions;

namespace Tower
{
    public class PlayerData : ISingleton
    {
        private PlayerData() { }

        public StringReactiveProperty Name = new StringReactiveProperty();
        public IntReactiveProperty Life = new IntReactiveProperty(100);
        public IntReactiveProperty Attack = new IntReactiveProperty(10);
        public IntReactiveProperty Defend = new IntReactiveProperty(10);

        public static PlayerData Instance
        {
            get
            {
                return SingletonProperty<PlayerData>.Instance;
            }
        }

        public void OnSingletonInit()
        {

        }
    }
}