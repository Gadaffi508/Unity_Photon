using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public TextMeshProUGUI playerName;
        public int playerindeks;
        private PhotonView _view;

        private void Start()
        {
            _view = GetComponent<PhotonView>();
            playerindeks = PhotonHandler.player.Count;
            PhotonHandler.player.Add(this.gameObject);
            
            if(!_view.IsMine) return;

            if (PhotonHandler.player.Count > 0)
            {
                transform.position = new Vector3(-4,0,0);
            }
            else
            {
                transform.position = new Vector3(4,0,0);
                transform.rotation = Quaternion.Euler(0,180,0);
            }

            playerName.text = _view.ViewID.ToString();
        }
    }
}