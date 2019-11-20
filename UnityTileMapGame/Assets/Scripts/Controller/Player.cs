namespace Tower
{
    using DG.Tweening;
    using QF;
    using QF.Action;
    using QF.Res;
    using QFramework;
    using UnityEngine;
    using UnityEngine.Tilemaps;

    public class Player : QMonoBehaviour, ISingleton
    {
        public PlayerData mPlayerData = PlayerData.Instance;

        public override IManager Manager => UIManager.Instance;
        public static Player Instance
        {
            get { return MonoSingletonProperty<Player>.Instance; }
        }

        public Tilemap wallTilemap;

        Vector3Int mTargetTilePos;
        public float mMoveSpeed = 0.3f;
        private bool isMoving;
        public bool mCanMove = true;
        string mColliderName;

        private void Start()
        {
            InitPlayerTilePos();
        }

        public void InitPlayerTilePos()
        {
            mTargetTilePos = new Vector3Int(Mathf.FloorToInt(transform.position.x), Mathf.FloorToInt(transform.position.y), 0); // 初始化玩家所在tile坐标 向下取整
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIMgr.OpenPanel<UIHomePanel>();
            }

            if (Input.GetKey(KeyCode.W))
            {
                PressEvent(PlayerAnimatorState.Up, Vector3Int.up);
                return;
            }
            if (Input.GetKey(KeyCode.S))
            {
                PressEvent(PlayerAnimatorState.Down, Vector3Int.down);
                return;
            }
            if (Input.GetKey(KeyCode.A))
            {
                PressEvent(PlayerAnimatorState.Left, Vector3Int.left);
                return;
            }
            if (Input.GetKey(KeyCode.D))
            {
                PressEvent(PlayerAnimatorState.Right, Vector3Int.right);
                return;
            }

            #region
            //if (!isMoving && mCanMove)
            //{
            //    if (Input.GetKey(KeyCode.W))
            //    {
            //        JudgeMove(Vector3Int.up);
            //        PlayerAnimatorMsg.Instance.ChangePlayerState(PlayerAnimatorState.Up);
            //        return;
            //    }
            //    if (Input.GetKey(KeyCode.S))
            //    {
            //        JudgeMove(Vector3Int.down);
            //        PlayerAnimatorMsg.Instance.ChangePlayerState(PlayerAnimatorState.Down);

            //        return;
            //    }
            //    if (Input.GetKey(KeyCode.A))
            //    {
            //        JudgeMove(Vector3Int.left);
            //        PlayerAnimatorMsg.Instance.ChangePlayerState(PlayerAnimatorState.Left);

            //        return;
            //    }
            //    if (Input.GetKey(KeyCode.D))
            //    {
            //        JudgeMove(Vector3Int.right);
            //        PlayerAnimatorMsg.Instance.ChangePlayerState(PlayerAnimatorState.Right);

            //        return;
            //    }
            //}
            #endregion

        }

        /// <summary>
        /// 手机端 遥感事件处理
        /// </summary>
        public void PressUp()
        {
            PressEvent(PlayerAnimatorState.Up, Vector3Int.up);
        }
        public void PressDown()
        {
            PressEvent(PlayerAnimatorState.Down, Vector3Int.down);
        }
        public void PressLeft()
        {
            PressEvent(PlayerAnimatorState.Left, Vector3Int.left);
        }
        public void PressRight()
        {
            PressEvent(PlayerAnimatorState.Right, Vector3Int.right);
        }

        void PressEvent(PlayerAnimatorState state, Vector3Int Dir)
        {
            if (!isMoving && mCanMove)
            {
                PlayerAnimatorMsg.Instance.ChangePlayerState(state);
                JudgeMove(Dir);
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
                    if (hit.collider.name + transform.position.x == mColliderName) // + transform.position.x 是因为需要避免两次碰到相同的collider
                    {
                        ChangeMovingState();
                        return;
                    }
                    mColliderName = hit.collider.name + transform.position.x;
                    Debug.Log(hit.collider.name);
                    Transform hitTransform = hit.collider.transform;
                    switch (hit.collider.tag)
                    {
                        case "Npc":  // 打开对话系统
                            hitTransform.GetComponent<Npc>().NpcExecute(hit.collider.name);
                            break;

                        case "Stair": // 切换关卡
                            this.SendMsg(new AudioSoundMsg("prop"));
                            hitTransform.GetComponent<Stair>().ChangeStair(hit.collider.name);
                            this.Sequence()
                                 .Delay(1.0f)
                                 .Event(() => Log.I("Delayed 1 second"))
                                 .Event(() => ChangeMovingState())
                                 .Begin();
                            break;
                        case "Door":
                            // 将要移动到的下一个位置是门
                            switch (hit.collider.name)
                            {
                                case "YellowDoor":
                                    if (mPlayerData.YellowKey.Value > 0)
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
        public void ChangeMovingState()
        {
            isMoving = false;
        }

        public void OnSingletonInit()
        {
        }
    }


}