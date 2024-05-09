using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        internal PhotonView _view;

        private void Start()
        {
            _view = GetComponent<PhotonView>();
            if(_view.IsMine is false) return;
            PhotonHandler.player.Add(this.gameObject);
            
            GetComponent<MeshRenderer>().material.color = Color.red;

            Starts();
        }

        private void Update()
        {
            if(_view.IsMine is false) return;
            Updates();
        }

        public virtual void Starts()
        {
            
        }
        
        public virtual void Updates()
        {
            
        }
        
        
    }

}