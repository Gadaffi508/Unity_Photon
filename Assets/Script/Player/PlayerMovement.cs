using System;
using Photon.Pun;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player.Movement
{
    public class PlayerMovement : Player
    {
        public TextMeshProUGUI playerName;
        public override void Starts()
        {
            playerName.gameObject.SetActive(true);
            playerName.text = "me";
        }
        
        public override void Updates()
        {
            if(_view.IsMine is false) return;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0,1,0,1);
            }
        }
    }
}