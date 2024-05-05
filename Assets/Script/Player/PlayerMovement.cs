using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public TextMeshProUGUI playerName;
        private PhotonView _view;

        private void Start()
        {
            _view = GetComponent<PhotonView>();
            if(_view.IsMine is false) return;
            PhotonHandler.player.Add(this.gameObject);
            
            GetComponent<MeshRenderer>().material.color = Color.red;

            playerName.text = "me";
        }

        private void Update()
        {
            if(_view.IsMine is false) return;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0,1,0,1);
            }
        }
    }
}