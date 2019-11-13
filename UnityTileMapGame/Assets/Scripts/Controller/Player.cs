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
        private bool isMoving;

        void Update()
        {
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(-17.5f, -4.5f, 0), mMoveSpeed * Time.deltaTime);


            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIMgr.OpenPanel<UIHomePanel>();
            }

            if (isMoving == false)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    isMoving = true;
                    mMoveDirection = Vector3.up;
                    PlayerMove();
                }
                if (Input.GetKey(KeyCode.S))
                {
                    isMoving = true;
                    mMoveDirection = Vector3.down;
                    PlayerMove();
                }
                if (Input.GetKey(KeyCode.A))
                {
                    isMoving = true;
                    mMoveDirection = Vector3.left;
                    PlayerMove();
                }
                if (Input.GetKey(KeyCode.D))
                {
                    isMoving = true;
                    mMoveDirection = Vector3.right;
                    PlayerMove();
                }
            }
        }
        void PlayerMove()
        {
            //transform.DOLocalMove(transform.position + mMoveDirection, mMoveSpeed).SetEase(Ease.Linear);
            //transform.GetComponent<Rigidbody2D>().DOMove(transform.position + mMoveDirection, mMoveSpeed).SetEase(Ease.Linear).OnComplete(changeMovingState);
            //transform.DOMove(transform.position + mMoveDirection, mMoveSpeed,).SetEase(Ease.Linear).OnComplete(changeMovingState);
        }
        void changeMovingState()
        {
            isMoving = false;
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