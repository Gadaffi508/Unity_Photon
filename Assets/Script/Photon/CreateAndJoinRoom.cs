using Photon.Pun; // Import Photon Unity Networking library for multiplayer functionality.
using Photon.Realtime; // Import Photon Realtime library for room management.
using TMPro; // Import TextMeshPro library for text handling.
using UnityEngine; // Import Unity Engine library for Unity-specific functions and classes.

namespace Photon.CreateAndJoinRoom // Define a namespace to encapsulate the CreateAndJoinRoom class.
{
    public class CreateAndJoinRoom : MonoBehaviourPunCallbacks // Define the CreateAndJoinRoom class as a MonoBehaviourPunCallbacks, enabling Photon callbacks.
    {
        public TMP_InputField createIF; // Reference to the TMP_InputField for entering room name for creation.
        public TMP_InputField joinIF; // Reference to the TMP_InputField for entering room name for joining.
        public TMP_Dropdown dropdown; // Reference to the TMP_Dropdown for selecting max players in the room.

        public TMP_Text warningText; // Reference to the TMP_Text for displaying warnings.

        public void CreateRoom() // Method called when the "Create Room" button is clicked.
        {
            if (createIF.text == "") // Check if the room name input field is empty.
            {
                warningText.gameObject.SetActive(true); // Activate the warning text.
                warningText.text = "Please enter room name"; // Set the warning message.
            }
            else
            {
                RoomOptions roomOptions = new RoomOptions(); // Create new RoomOptions object for custom room settings.
                roomOptions.MaxPlayers = dropdown.value + 2; // Set the maximum number of players in the room based on dropdown selection.
                PhotonNetwork.CreateRoom(createIF.text, roomOptions); // Create a new room with the specified name and options.
            }
        }

        public void JoinRoom() // Method called when the "Join Room" button is clicked.
        {
            if (joinIF.text == "") // Check if the room name input field is empty.
            {
                warningText.gameObject.SetActive(true); // Activate the warning text.
                warningText.text = "Please enter room name"; // Set the warning message.
            }
            else
            {
                PhotonNetwork.JoinRoom(joinIF.text); // Join the room with the specified name.
            }
        }

        public void RandomRoom() // Method called when the "Join Random Room" button is clicked.
        {
            PhotonNetwork.JoinRandomRoom(); // Join a random room available in the network.
        }

        public override void OnJoinedRoom() // Callback method called when successfully joined a room.
        {
            PhotonNetwork.LoadLevel("GameScene"); // Load the specified scene for gameplay.
        }
    }
}
