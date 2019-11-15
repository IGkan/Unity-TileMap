namespace Tower
{
    using DG.Tweening;
    using QF;
    using QF.Res;
    using QFramework;
    using UnityEngine;
    using UnityEngine.Tilemaps;

    public class Player : QMonoBehaviour,ISingleton
    {
        public PlayerData mPlayerData = PlayerData.Instance;

        public override IManager Manager => UIManager.Instance;
        public static Player Instance
        {
            get { return MonoSingletonProperty<Player>.Instance ;}
        }

        public Tilemap wallTilemap;

        Vector3Int mTargetTilePos;
        public float mMoveSpeed = 0.3f;
        private bool isMoving;
        bool mCanMove = true;
       
        private void Start()
        {
            InitPlayerTilePos();
        }

        public void InitPlayerTilePos () {
            mTargetTilePos = new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0); // 初始化玩家所在tile坐标 向下取整
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIMgr.OpenPanel<UIHomePanel>();
            }

            if (!isMoving && mCanMove)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    JudgeMove(new Vector3Int(0,1,0));
                    return;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    JudgeMove(new Vector3Int(0, -1,0));
                    return;

                }
                if (Input.GetKey(KeyCode.A))
                {
                    JudgeMove(new Vector3Int(-1, 0,0));
                    return;

                }
                if (Input.GetKey(KeyCode.D))
                {
                    JudgeMove(new Vector3Int(1, 0,0));
                    return;

                }
            }
            
        }

        /// <summary>
        /// 得到下一个坐标玩家是否可以移动
        /// </summary>
        void JudgeMove(Vector3Int mMoveDirectionCell)
        {
            isMoving = true;

            //取出主角下一步将要移动到的所在的方格名稱
            bool hasTile = wallTilemap.HasTile(mTargetTilePos + mMoveDirectionCell);

            if (!hasTile)
            {
             
                RaycastHit2D hit = Physics2D.Raycast(transform.position + mMoveDirectionCell, Vector2.zero);
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                   Transform hitTransform = hit.collider.transform;
                    switch (hit.collider.tag)
                    {
                        case "Npc":
                            ChangeMovingState();
                            this.SendMsg(new AudioSoundMsg("talk"));
                            // 打开对话系统
                            switch (hit.collider.name)
                            {
                                case "npc1_12":
                                    mPlayerData.YellowKey.Value += 1;
                                    mPlayerData.RedKey.Value += 1;
                                    mPlayerData.PurpleKey.Value += 1;
                                    break;
                                default:
                                    break;
                            }
                            break;
                        case "Stair":
                            ChangeMovingState();
                            this.SendMsg(new AudioSoundMsg("prop"));
                            hitTransform.GetComponent<Stair>().ChangeStair(hit.collider.name);
                            break;
                        case "Door":
                            // 将要移动到的下一个位置是门
                            switch (hit.collider.name)
                            {
                                case "YellowDoor":
                                    if(mPlayerData.RedKey.Value > 0)
                                    {
                                        this.SendMsg(new AudioSoundMsg("door"));

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
                                        this.SendMsg(new AudioSoundMsg("door"));

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
                                        this.SendMsg(new AudioSoundMsg("door"));

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
                            bool fightWinBool = hitTransform.GetComponent<Monster>().MonsterExecute(hit.collider);
                            if (fightWinBool)
                            {
                                this.SendMsg(new AudioSoundMsg("fight"));
                                PlayerMove(mMoveDirectionCell);
                            }
                            else
                            {
                                ChangeMovingState();
                            }
                            break;
                        case "Prop":
                            this.SendMsg(new AudioSoundMsg("prop"));
                            hitTransform.GetComponent<Prop>().PropExecute(hitTransform.name);
                            PlayerMove(mMoveDirectionCell);
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

        public void OnSingletonInit()
        {
        }
    }
   

}