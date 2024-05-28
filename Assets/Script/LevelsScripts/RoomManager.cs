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

    [Space]
    public GameObject nameGUI;
    public GameObject connectionGUI;

    private string nickName = "unnamed";
    
    void Start()
    {
        
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

        _player.GetComponent<PhotonView>().RPC("SetNickName",RpcTarget.All,nickName);
    }

    public void ChangeNickName(string _name)
    {
        nickName = _name;
    }

    public void JoinRoomButtonPressed()
    {
        Debug.Log("Connecting...");

        PhotonNetwork.ConnectUsingSettings();

        nameGUI.SetActive(false);
        connectionGUI.SetActive(true);
    }
}
