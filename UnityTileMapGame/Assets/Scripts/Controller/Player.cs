namespace Tower
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public PlayerData mPlayerData = PlayerData.Instance;
        void Update()
        {
            if (transform.localPosition.y < -10f)
            {
                transform.localPosition = Vector3.zero;
            }
        }
    }

}