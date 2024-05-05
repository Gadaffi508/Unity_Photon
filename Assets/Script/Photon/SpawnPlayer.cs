using System;
using UnityEngine;
using Photon.Pun;
using Random = UnityEngine.Random;

namespace Photon.SpawnPlayers
{
    public class SpawnPlayer : MonoBehaviour
    {
        public GameObject player;

        public float minX, maxX, minZ, maxZ;

        private void Start()
        {
            Vector3 randomPos = new Vector3(Random.Range(minX,maxX),1,Random.Range(minZ,maxZ));

            PhotonNetwork.Instantiate(player.name, randomPos, Quaternion.identity);
        }
    }
}