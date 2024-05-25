using UnityEngine;

namespace Player.Weapon.Sway
{
    public class Sway : MonoBehaviour
    {
        [Header("Setting")]
        public float swayClamb = 0.89f;

        [Space]
        public float smoothing = 3f;

        private Vector3 _origin;

        private void Start()
        {
            _origin = transform.position;
        }

        private void Update()
        {
            Vector2 input = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));

            input.x = Mathf.Clamp(input.x,-swayClamb,swayClamb);
            input.y = Mathf.Clamp(input.y,-swayClamb,swayClamb);

            Vector3 target = new Vector3(-input.x,-input.y,0);

            transform.localPosition = Vector3.Lerp(transform.localPosition,target + _origin,Time.deltaTime * smoothing);
        }
    }
}
