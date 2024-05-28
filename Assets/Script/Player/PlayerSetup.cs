using Photon.Pun;
using TMPro;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovementExample movement;
    
    public GameObject cameraPlayer;

    public string nickName;

    public TextMeshProUGUI nickNameText;

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        cameraPlayer.SetActive(true);
    }

    [PunRPC]
    public void SetNickName(string _name)
    {
        nickName = _name;

        nickNameText.text = nickName;
    }
}