namespace Tower
{
    using QF.Extensions;
    using UnityEngine;

    public class Enemy09_00 : Monster
    {
        private void Start()
        {
            name = "Enemy09_00";
            mAttack = 10;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            PlayerData.Instance.Life.Value -= mAttack;
            gameObject.Hide();
        }


    }

}