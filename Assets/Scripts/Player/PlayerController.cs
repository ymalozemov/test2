using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;

        private void Update()
        {
            var moveHorizontal = Input.GetAxis("Horizontal");
            var moveVertical = Input.GetAxis("Vertical");
            var movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            var deltaTime = Time.deltaTime;
            var deltaSpeed = moveSpeed * deltaTime;
            transform.position += movement * deltaSpeed;
        }
    }
}