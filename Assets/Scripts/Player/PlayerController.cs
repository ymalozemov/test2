using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private float _moveSpeed = 1f;
        private float _turnSpeed = 700f;
        private float _transitionTime = 1f; 
        private Animator _animator;
        private int _isStandingHash;
        private int _isWalkingHash;
        private int _isRuningHash;
        private Rigidbody _rb; // Ссылка на компонент Rigidbody
        private float _timer;
        
        void Start()
        {
            _isStandingHash = Animator.StringToHash("isStanding");
            _isWalkingHash = Animator.StringToHash("isWalk");
            _isRuningHash = Animator.StringToHash("isRun");
            _animator = GetComponent<Animator>();
            _animator.SetBool(_isStandingHash, true);
            _timer = 0f;
        }
        
        private void Update()
        {
            
            var moveHorizontal = Input.GetAxis("Horizontal"); // A/D или стрелки влево/вправо
            var moveVertical = Input.GetAxis("Vertical"); // W/S или стрелки вверх/вниз
            var deltaSpeed = _moveSpeed * Time.deltaTime;
            var movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * deltaSpeed;

            transform.Translate(movement, Space.World);
            
            if (movement != Vector3.zero)
            {
                _animator.SetBool(_isStandingHash, false);
                _animator.SetBool(_isWalkingHash, true);
                _timer += Time.deltaTime;
                Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _turnSpeed * Time.deltaTime);
                if (_timer >= _transitionTime)
                {
                    _moveSpeed = 4f;
                    _animator.SetBool(_isStandingHash, false);
                    _animator.SetBool(_isWalkingHash, false);
                    _animator.SetBool(_isRuningHash, true);
                }
            }
            else
            {
                _animator.SetBool(_isWalkingHash, false);
                _animator.SetBool(_isStandingHash, true);
                _animator.SetBool(_isRuningHash, false);
                _timer = 0f;
                _moveSpeed = 2f;
            }
            
        }
    }
}