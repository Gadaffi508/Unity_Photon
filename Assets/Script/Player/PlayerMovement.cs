using Photon.Pun; // Import Photon Unity Networking library for multiplayer functionality.
using TMPro; // Import TextMeshPro library for text handling.
using UnityEngine; // Import Unity Engine library for Unity-specific functions and classes.

namespace Player.Movement // Define a namespace to encapsulate the PlayerMovement class.
{
    public class PlayerMovement : Player // Define the PlayerMovement class as a child of the Player class.
    {
        public TextMeshProUGUI playerName; // Reference to the TextMeshProUGUI component for displaying player name.
        private Rigidbody _rb; // Reference to the Rigidbody component for physics interactions.
        private bool _isjump = true; // Boolean to track if the player can jump.

        public override void Starts() // Method called at the start of the GameObject's lifecycle, overrides parent method.
        {
            playerName.gameObject.SetActive(true); // Activate the playerName TextMeshProUGUI object.
            playerName.text = "me"; // Set the player's name text.
            _rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject.
        }
        
        public override void Updates() // Method called every frame, overrides parent method.
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isjump is true) // Check if Space key is pressed and player can jump.
            {
                _rb.AddForce(transform.up * 350); // Apply upward force to simulate jumping.
                _isjump = false; // Set jump status to false to prevent multiple jumps.
            }
        }

        [PunRPC] // Declare a method as a remote procedure call to be invoked over the network.
        private void OnCollisionEnter(Collision other) // Method called when this GameObject collides with another.
        {
            if (other.gameObject.CompareTag("Ground")) // Check if the collided object is tagged as "Ground".
            {
                _isjump = true; // Set jump status to true, allowing the player to jump again.
            }
        }
    }
}
