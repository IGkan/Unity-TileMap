namespace Tower
{
    using QF.Res;
    using QFramework;
    using UnityEngine;

    public class Player : QMonoBehaviour
    {
        public PlayerData mPlayerData = PlayerData.Instance;

        public override IManager Manager => UIManager.Instance;

        void Update()
        {
            if (transform.localPosition.y < -20f)
            {
                transform.localPosition = Vector3.zero;
                PlayerData.Instance.InitPlayerData();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                UIMgr.OpenPanel<UIHomePanel>();
            }
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