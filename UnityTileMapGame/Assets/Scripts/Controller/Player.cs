namespace Tower
{
    using DG.Tweening;
    using QF.Res;
    using QFramework;
    using UnityEngine;

    public class Player : QMonoBehaviour
    {
        public PlayerData mPlayerData = PlayerData.Instance;

        public override IManager Manager => UIManager.Instance;

        Vector3 mMoveDirection;
        float mMoveSpeed = 0.3f;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIMgr.OpenPanel<UIHomePanel>();
            }
            if(Input.GetKey(KeyCode.W))
            {
                mMoveDirection = Vector3.up;
                PlayerMove();
            }
            if (Input.GetKey(KeyCode.S))
            {
                mMoveDirection = Vector3.down;
                PlayerMove();
            }
            if (Input.GetKey(KeyCode.A))
            {
                mMoveDirection = Vector3.left;
                PlayerMove();
            }
            if (Input.GetKey(KeyCode.D))
            {
                mMoveDirection = Vector3.right;
                PlayerMove();
            }
        }
        void PlayerMove()
        {
            transform.DOMove(transform.position + mMoveDirection, mMoveSpeed).SetEase(Ease.Linear);
            //transform.DOMove(transform.position + mMoveDirection, mMoveSpeed).SetEase(Ease.Linear).OnComplete(changeMovingState);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var playerData = PlayerData.Instance;
            if (collision.CompareTag("Prop"))
            {
                this.SendMsg(new AudioSoundMsg("prop"));
                switch (collision.name)
                {
                    case "Life":
                        playerData.Life.Value += 10;
                        break;
                    case "Attack":
                        playerData.Attack.Value += 2;
                        break;
                    case "Defend":
                        playerData.Defend.Value += 2;
                        break;
                    case "Level":
                        playerData.Level.Value += 1;
                        break;
                    case "Experience":
                        playerData.Experience.Value += 10;
                        break;
                    case "Gold":
                        playerData.Gold.Value += 10;
                        break;
                    default:
                        break;
                }
            }
           
        }

      
    }
   

}