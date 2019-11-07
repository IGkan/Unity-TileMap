namespace Tower
{
    using UnityEngine;
    public class Monster:MonoBehaviour
    {
        protected string mName;
        protected int mAttack;
        protected int mDefend;

        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {

        }
    }

}