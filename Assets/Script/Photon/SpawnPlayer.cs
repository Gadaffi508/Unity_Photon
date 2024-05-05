using UnityEngine;
using Photon.Pun;

namespace Photon.SpawnPlayers
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject player;
        public Transform spawnPoint1;
        public Transform spawnPoint2;

        private void Start()
        {
            if (PhotonNetwork.IsConnected)
            {
                int playerIndex = PhotonNetwork.PlayerList.Length;

                Vector3 spawnPosition;
                Quaternion spawnRotation;

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