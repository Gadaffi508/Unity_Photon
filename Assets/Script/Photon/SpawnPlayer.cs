using UnityEngine;
using Photon.Pun;

namespace Photon.SpawnPlayers
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject player;

        private void Start()
        {
            PhotonNetwork.Instantiate(player.name, Vector3.one, Quaternion.identity);
        }
    }
}