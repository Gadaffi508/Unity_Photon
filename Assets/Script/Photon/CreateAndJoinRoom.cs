using Photon.Pun;
using Photon.Realtime;
using TMPro;

namespace Photon.CreateAndJoinRoom
{
    public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
    {
        public TMP_InputField createIF;
        public TMP_InputField joinIF;
        public TMP_Dropdown dropdown;

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
                RoomOptions roomOptions = new RoomOptions();
                roomOptions.MaxPlayers = dropdown.value + 2;
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
            PhotonNetwork.LoadLevel("GameScene");
        }
    }
}