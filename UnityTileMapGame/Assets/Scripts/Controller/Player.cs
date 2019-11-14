namespace Tower
{
    using DG.Tweening;
    using QF.Res;
    using QFramework;
    using System;
    using UnityEngine;
    using UnityEngine.Tilemaps;
    using static UnityEngine.Tilemaps.Tile;

    public class Player : QMonoBehaviour
    {
        public PlayerData mPlayerData = PlayerData.Instance;

        public override IManager Manager => UIManager.Instance;

        public Tilemap wallTilemap;

        Vector3Int mTargetTilePos;
        float mMoveSpeed = 0.3f;
        private bool isMoving;
        private void Start()
        {
            mTargetTilePos = new Vector3Int(Mathf.FloorToInt(transform.position.x),Mathf.FloorToInt(transform.position.y),0); // 初始化玩家所在tile坐标 向下取整
        }
        void Update()
        {
            Debug.Log(mPlayerData.RedKey.Value);
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIMgr.OpenPanel<UIHomePanel>();
            }

            if (!isMoving)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    isMoving = true;
                    JudgeMove(new Vector3Int(0,1,0));
                }
                if (Input.GetKey(KeyCode.S))
                {
                    isMoving = true;
                    JudgeMove(new Vector3Int(0, -1,0));
                }
                if (Input.GetKey(KeyCode.A))
                {
                    isMoving = true;
                    JudgeMove(new Vector3Int(-1, 0,0));
                }
                if (Input.GetKey(KeyCode.D))
                {
                    isMoving = true;
                    JudgeMove(new Vector3Int(1, 0,0));
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// 得到下一个坐标玩家是否可以移动
        /// </summary>
        void JudgeMove(Vector3Int mMoveDirectionCell)
        {
            //取出主角下一步将要移动到的所在的方格名稱
            bool hasTile = wallTilemap.HasTile(mTargetTilePos + mMoveDirectionCell);

            if (!hasTile)
            {
             
                RaycastHit2D hit = Physics2D.Raycast(transform.position + mMoveDirectionCell, Vector2.zero);
                if (hit.collider != null)
                {
                    switch (hit.collider.tag)
                    {
                        case "Npc":
                            break;
                        case "Door":
                            // 将要移动到的下一个位置是门
                            switch (hit.collider.name)
                            {
                                case "YellowDoor":
                                    if(mPlayerData.YellowKey.Value > 0)
                                    {
                                        mPlayerData.YellowKey.Value -= 1;
                                        hit.collider.gameObject.SetActive(false);
                                        PlayerMove(mMoveDirectionCell);

                                    }
                                    else
                                    {
                                        ChangeMovingState();

                                    }
                                    break;
                                case "RedDoor":
                                    if (mPlayerData.RedKey.Value > 0)
                                    {
                                        mPlayerData.RedKey.Value -= 1;
                                        hit.collider.gameObject.SetActive(false);
                                        PlayerMove(mMoveDirectionCell);

                                    }
                                    else
                                    {
                                        ChangeMovingState();

                                    }
                                    break;
                                case "PurpleDoor":
                                    if (mPlayerData.PurpleKey.Value > 0)
                                    {
                                        mPlayerData.PurpleKey.Value -= 1;
                                        hit.collider.gameObject.SetActive(false);
                                        PlayerMove(mMoveDirectionCell);

                                    }
                                    else
                                    {
                                        ChangeMovingState();

                                    }
                                    break;
                                default:
                                    Debug.LogError("The door's collider maybe wrong!!!");
                                    break;
                            }
                            break;
                        case "Monster":
                            break;
                        case "Prop":
                            break;


                        default:
                            break;
                    }
                }
                else
                {
                    PlayerMove(mMoveDirectionCell);

                }
            }
            else
            {
                ChangeMovingState();
            }
        }


        void PlayerMove(Vector3Int mMoveDirectionCell)
        {
            mTargetTilePos += mMoveDirectionCell;
            transform.DOMove(transform.position + mMoveDirectionCell, mMoveSpeed).SetEase(Ease.Linear).OnComplete(ChangeMovingState);
        }
        void ChangeMovingState()
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