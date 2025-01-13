using UnityEngine;

namespace App.Art.Environments.Shield.Scripts
{
    public class Level : MonoBehaviour
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
            var size = App.Managers.PlayerPrefsManager.LoadPlayerData();
            main.startSize = size.shieldLevel;
            _particleSystem.Play();
        }
    }
}