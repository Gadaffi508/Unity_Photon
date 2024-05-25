using UnityEngine;
using Photon.Pun;
using TMPro;

namespace Player.Health
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("UI")]
        public TextMeshProUGUI health_text;

        public int health;

        public bool isLocalPlayer;  

        [PunRPC]
        public void TakeDamage(int _damage)
        {
            health = _damage;

            health_text.text = health.ToString();

            if (health <= 0)
            {
                if(isLocalPlayer)
                    RoomManager.Instance.RespawnPlayer();

                Destroy(gameObject);
            }
        }
    }
}
