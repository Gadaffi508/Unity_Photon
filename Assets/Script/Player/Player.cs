using Photon.Pun; // Import Photon Unity Networking library for multiplayer functionality.
using UnityEngine; // Import Unity Engine library for Unity-specific functions and classes.

namespace Player // Define a namespace to encapsulate the Player class.
{
    public class Player : MonoBehaviour // Define the Player class as a MonoBehaviour, making it a script for Unity GameObjects.
    {
        internal PhotonView _view; // Internal variable to hold the PhotonView component reference for networking.

        private void Start() // Start method called when the GameObject is initialized.
        {
            _view = GetComponent<PhotonView>(); // Get the PhotonView component attached to this GameObject.
            if(_view.IsMine is false) return; // If this instance is not owned by the local player, exit the method.

            PhotonHandler.player.Add(this.gameObject); // Add this GameObject to the list of players managed by Photon.

            GetComponent<MeshRenderer>().material.color = Color.red; // Set the color of the MeshRenderer component to red.

            Starts(); // Call the Starts method, which can be overridden by child classes.
        }

        private void Update() // Update method called once per frame.
        {
            if(_view.IsMine is false) return; // If this instance is not owned by the local player, exit the method.

            Updates(); // Call the Updates method, which can be overridden by child classes.

            if (PhotonNetwork.IsConnected is false) // If this instance is connected control by the local player.
            {
                Debug.Log("Player disconnected"); // Player is disconnected unity debug see
                PhotonHandler.player.Remove(this.gameObject); // Remove this GameObject to the list of players managed by Photon.
            }
        }

        public virtual void Starts() // Method called at the start of the GameObject's lifecycle, can be overridden.
        {
            // This method can be implemented in child classes to perform specific actions at the start.
        }
        
        public virtual void Updates() // Method called every frame, can be overridden.
        {
            // This method can be implemented in child classes to perform specific actions each frame.
        }
    }
}