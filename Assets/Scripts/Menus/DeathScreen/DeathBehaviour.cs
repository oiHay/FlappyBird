using Manager;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus.DeathScreen
{
    public class DeathBehaviour : MonoBehaviour
    { 
        [SerializeField] private GameObject deathScreenPanel;

        private void OnEnable()
        {
            GameManager.OnGameOver += ShowDeathScreen;
        }

        private void OnDisable()
        {
            GameManager.OnGameOver -= ShowDeathScreen;
        }

        private void Start()
        {
            deathScreenPanel.SetActive(false);
        }

        private void ShowDeathScreen()
        {
            deathScreenPanel.SetActive(true);
        }

        public void Restart()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.RestartGameState();
            }

            SceneManager.LoadScene("SampleScene");
        }
    }
}

