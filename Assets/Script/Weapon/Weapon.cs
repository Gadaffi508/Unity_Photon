using Photon.Pun;
using Player.Health;
using TMPro;
using UnityEngine;

namespace Player.Weapon
{
    public class Weapon : MonoBehaviour
    {
        public int damage;

        public float fireRate;

        public Camera camera;

        private float _nextFire;

        [Header("VFX")]
        public GameObject hitVFX;

        [Header("Ammo")]
        public int mag = 5;
        public int ammo = 30;
        public int magAmmo = 30;

        [Header("UI")]
        public TextMeshProUGUI ammoText;
        public TextMeshProUGUI magText;

        //<--------------------------------------Variables--------------------------------------->

        private void Start()
        {
            ShowTextAmmo();
        }

        private void Update()
        {
            if(_nextFire > 0)
                _nextFire -= Time.deltaTime;

            if (Input.GetMouseButton(0) && _nextFire <= 0 && ammo > 0)
            {
                _nextFire = 1 / fireRate;

                ammo--;

                ShowTextAmmo();

                Fire();
            }

            if(Input.GetKeyDown(KeyCode.R)) Reload();

            if (ammo <= 0) Reload();
        }

        //<--------------------------------------Functions--------------------------------------->

        void Fire()
        {
            Ray ray = new Ray(camera.transform.position,camera.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray.origin,ray.direction,out hit,100f))
            {
                PhotonNetwork.Instantiate(hitVFX.name,hit.point,Quaternion.identity);

                if (hit.transform.gameObject.GetComponent<PlayerHealth>())
                {
                    hit.transform.gameObject.GetComponent<PhotonView>().RPC("TakeDamage",RpcTarget.All,damage);
                }
            }
        }

        void Reload()
        {

            if(mag>0)
            {
                mag--;

                ammo = magAmmo;
            }

            ShowTextAmmo();
        }

        void ShowTextAmmo()
        {
            magText.text = mag.ToString();
            ammoText.text = ammo + " / " + magAmmo;
        }
    }
}
