using Photon.Pun;
using TMPro;

namespace Photon.CreateAndJoinRoom
{
    public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
    {
        public TMP_InputField createIF;
        public TMP_InputField joinIF;

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(createIF.text);
        }
        
        public void JoinRoom()
        {
            PhotonNetwork.JoinRoom(joinIF.text);
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