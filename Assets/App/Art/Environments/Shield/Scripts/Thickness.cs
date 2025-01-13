using UnityEngine;

namespace Art.Environments.Shield.Scripts
{
    public class Thickness : MonoBehaviour
    {
        private ParticleSystem _particleSystem;

        private void Start()
        {
            _particleSystem = GetComponent<ParticleSystem>();
            if (_particleSystem != null) _setStartSize();
        }

        private void _setStartSize()
        {
            var main = _particleSystem.main;
            main.startSize = 5.0f;
        }
    }
}