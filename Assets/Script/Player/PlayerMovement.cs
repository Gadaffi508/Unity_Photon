using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovement : Player
    {
        public TextMeshProUGUI playerName;
        private Rigidbody _rb;
        private bool _isjump = true;
        public override void Starts()
        {
            playerName.gameObject.SetActive(true);
            playerName.text = "me";
            _rb = GetComponent<Rigidbody>();
        }
        
        public override void Updates()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isjump is true)
            {
                _rb.AddForce(transform.up * 350);
                _isjump = false;
            }
        }

        [PunRPC]
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                _isjump = true;
            }
        }
    }
}