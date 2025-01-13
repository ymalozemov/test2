using UnityEngine;

namespace App.Camera
{
    public class Controller : MonoBehaviour
    {
        public Vector3 offset;
        private Transform _target;

        private void Start()
        {
            _target = FindFirstObjectByType<Player.Controller>().transform;


            if (offset == Vector3.zero)
            {
                offset = new Vector3(0, 5, -10);
            }
        }

        private void LateUpdate()
        {
            Vector3 desiredPosition = _target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);
        }
    }
}