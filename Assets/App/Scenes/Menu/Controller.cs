using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace App.Scenes.Menu
{
    public class Main : MonoBehaviour
    {
        public Button startButton;

        void Start()
        {
            if (startButton == null) return;
            startButton.onClick.AddListener(StartGame);
        }

        void StartGame()
        {
            SceneManager.LoadScene(ScenesNames.Scenes.MainScene.ToString());
        }
    }
}