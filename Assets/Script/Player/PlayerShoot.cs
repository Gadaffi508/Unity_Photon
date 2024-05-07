using System;
using UnityEngine;

namespace Player.Shoot
{
    public class PlayerShoot : Player
    {
        [Range(1,5)]
        public float shootTime;
        
        private Animator _animator;
        private float _timer = 0;
        public override void Starts()
        {
            _animator = GetComponent<Animator>();
        }
        public override void Updates()
        {
            _timer += Time.deltaTime;
            
            if (Input.GetMouseButton(0) && shootTime<_timer)
            {
                _animator.SetTrigger("Shoot");
                _timer = 0;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Debug.Log("Player touched");
            }
        }
    }
}
