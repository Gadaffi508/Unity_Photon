using Photon.Pun;
using UnityEngine.SceneManagement;

namespace Photon.ConnectToServer
{
    public class ConnectToServer : MonoBehaviourPunCallbacks
    {
        private void Start()
        {
            //Photon get setting data
            PhotonNetwork.ConnectUsingSettings();
        }

        //Connection Successful for work code
        public override void OnConnectedToMaster()
        {
            //Lobby connect
            PhotonNetwork.JoinLobby();
        }

        //JoinLobby Successful for work code
        public override void OnJoinedLobby()
        {
            SceneManager.LoadScene("LobbyScene");
        }
    }
}