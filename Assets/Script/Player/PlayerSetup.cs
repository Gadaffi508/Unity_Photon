using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public PlayerMovementExample movement;
    
    public GameObject cameraPlayer;

    public void IsLocalPlayer()
    {
        movement.enabled = true;
        cameraPlayer.SetActive(true);
    }
}