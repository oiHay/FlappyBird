using TMPro;
using UnityEngine;

namespace Manager
{
    public class ScoreManager : MonoBehaviour
    {
        [Header("Score Components References")] 
        [SerializeField] private TextMeshProUGUI scoreText;
        
        public static int Score { get; private set; }
        
        // public static event Action OnScoreChanged;

        private void OnEnable()
        {
            // GameManager.OnGameOver += HandleGameOver;
            GameManager.OnGameRestarted += HandleGameRestarted;
            UpdateScoreText();
        }

        private void OnDisable()
        {
            // GameManager.OnGameOver -= HandleGameOver;
            GameManager.OnGameRestarted -= HandleGameRestarted;
        }
        
        public static void HandleScoreChanged()
        {
            Score += 1;
        }
        
        private void HandleGameRestarted()
        {
            Score = 0;
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            if (scoreText != null)
            {
                scoreText.text = Score.ToString();
            }
        }

        private void Update()
        {
            UpdateScoreText();
        }
    }
}
