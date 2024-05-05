using Photon.Pun;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed;
        
        private Rigidbody _rb;
        private float _x, _y;
        private Vector3 _dir = Vector3.zero;
        private PhotonView _view;

        private void Start()
        {
            _view = GetComponent<PhotonView>();
            
            if(!_view.IsMine) return;
            
            _rb = GetComponent<Rigidbody>();
        } 

        private void Update()
        {
            if(!_view.IsMine) return;
            _x = Input.GetAxis("Horizontal");
            _y = Input.GetAxis("Vertical");
        }

        private void FixedUpdate()
        {
            if(!_view.IsMine) return;
            _dir = new Vector3(_x * Time.deltaTime * speed,0,_y * Time.deltaTime * speed);
            
            _rb.velocity = _dir;
        }
    }
}