using UnityEngine;
using Photon.Pun;
using Player.Health;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance { get; private set; }
    private void Awake() => Instance = this;

    public GameObject player;
    [Space] public Transform spawnPoint;
    [Space] public GameObject roomCam;
    
    void Start()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        
        Debug.Log("Connected to Server");

        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        
        Debug.Log("We're in the lobby");

        PhotonNetwork.JoinOrCreateRoom("Test",null,null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
        Debug.Log("We're connected and in a room!");

        roomCam.SetActive(false);

        RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);

        _player.GetComponent<PlayerSetup>().IsLocalPlayer();

        _player.GetComponent<PlayerHealth>().isLocalPlayer = true;
    }
}
