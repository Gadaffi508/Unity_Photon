using UnityEngine; // Import Unity Engine library for Unity-specific functions and classes.
using Photon.Pun; // Import Photon Unity Networking library for multiplayer functionality.

namespace Photon.SpawnPlayers  // Define a namespace to encapsulate the SpawnPlayers class.
{
    public class SpawnPlayer : MonoBehaviour  // Define the SpawnPlayer class as a child of the Photon class.
    {
        public GameObject player; //online player spawn object
        public Transform spawnPoint1; //one player spawn point
        public Transform spawnPoint2; //second player spawn point

        private void Start() // / Method called at the start of the GameObject's lifecycle.
        {
            if (PhotonNetwork.IsConnected) // If this instance is connected control by the local player.
            {
                int playerIndex = PhotonNetwork.PlayerList.Length; // playerIndex created int variable for get player members

                Vector3 spawnPosition; // spawnPosition created Vector3 variable for ınstate pos free
                Quaternion spawnRotation; // spawnRotation created Quaternion variable for ınstate object rotation value

                if (playerIndex == 1)
                {
                    spawnPosition = spawnPoint1.position;
                    spawnRotation = spawnPoint1.rotation;
                }
                else
                {
                    spawnPosition = spawnPoint2.position;
                    spawnRotation = spawnPoint2.rotation;
                }

                PhotonNetwork.Instantiate(player.name, spawnPosition, spawnRotation);
            }
        }
    }
}