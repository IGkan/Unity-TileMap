namespace Tower
{
    using QF;
    using UnityEngine;
    public enum PlayerAnimatorState
    {
        Down,
        Right,
        Up,
        Left

    }

    public class PlayerAnimatorMsg : MonoBehaviour,ISingleton
    {
        public static PlayerAnimatorMsg Instance
        {
            get { return MonoSingletonProperty<PlayerAnimatorMsg>.Instance; }
        }

        public Animator Ani;
        void Start()
        {
            Ani = GetComponent<Animator>();
        }

        public void ChangePlayerState(PlayerAnimatorState state)
        {
            switch (state)
            {
                case PlayerAnimatorState.Left:
                    Ani.SetTrigger("isLeft");
                    break;
                case PlayerAnimatorState.Right:
                    Ani.SetTrigger("isRight");
                    break;
                case PlayerAnimatorState.Up:
                    Ani.SetTrigger("isUp");
                    break;
                case PlayerAnimatorState.Down:
                    Ani.SetTrigger("isDown");
                    break;
                default:
                    break;
            }
        }

        public void OnSingletonInit()
        {
        }
    }

}