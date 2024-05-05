using Photon.Pun;
using TMPro;
using UnityEngine;

namespace Photon.CreateAndJoinRoom
{
    public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
    {
        public TMP_InputField createIF;
        public TMP_InputField joinIF;

        public TMP_Text warnıngText;

        public void CreateRoom()
        {
            if (createIF.text == "")
            {
                warnıngText.gameObject.SetActive(true);
                warnıngText.text = "Please enter room name";
            }
            else
            {
                PhotonNetwork.CreateRoom(createIF.text);
            }
        }
        
        public void JoinRoom()
        {
            if (joinIF.text == "")
            {
                warnıngText.gameObject.SetActive(true);
                warnıngText.text = "Please enter room name";
            }
            else
            {
                PhotonNetwork.JoinRoom(joinIF.text);
            }
        }

        public void RandomRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount<3)
            {
                PhotonNetwork.LoadLevel("GameScene");
            }
            else
            {
                warnıngText.gameObject.SetActive(true);
                warnıngText.text = "Room is full";
            }
        }
    }
}