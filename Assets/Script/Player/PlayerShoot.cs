using Photon.Pun; // Import Photon Unity Networking library for multiplayer functionality.
using UnityEngine; // Import Unity Engine library for Unity-specific functions and classes.

namespace Player.Shoot // Define a namespace to encapsulate the PlayerShoot class.
{
    public class PlayerShoot : Player // Define the PlayerShoot class as a child of the Player class.
    {
        [Range(1,5)] // Attribute to restrict the range of values for shootTime.
        public float shootTime; // Time interval between each shot.

        private Animator _animator; // Reference to the Animator component for animation control.
        private float _timer = 0; // Timer to track time between shots.

        public override void Starts() // Method called at the start of the GameObject's lifecycle, overrides parent method.
        {
            _animator = GetComponent<Animator>(); // Get the Animator component attached to this GameObject.
        }

        public override void Updates() // Method called every frame, overrides parent method.
        {
            _timer += Time.deltaTime; // Increment the timer by the time passed since the last frame.

            if (Input.GetMouseButton(0) && shootTime < _timer) // Check if left mouse button is pressed and shootTime interval has elapsed.
            {
                _animator.SetTrigger("Shoot"); // Trigger the "Shoot" animation in the Animator.
                _timer = 0; // Reset the timer for the next shot.
            }
        }

        [PunRPC] // Declare a method as a remote procedure call to be invoked over the network.
        private void OnTriggerEnter(Collider other) // Method called when this GameObject enters a trigger collider.
        {
            if (other.gameObject.CompareTag("Player")) // Check if the trigger collider belongs to another player.
            {
                Debug.Log("Player touched"); // Log a message indicating that the player has been touched.
            }
        }
    }
}