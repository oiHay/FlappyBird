using System;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
    
        public static bool IsGameOver { get; private set; }

        public static event Action OnGameOver;
        public static event Action OnGameRestarted;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            IsGameOver = false;
        }

        public void GameOver()
        {
            if (IsGameOver)
            {
                return;
            }
        
            IsGameOver = true;
            OnGameOver?.Invoke();
        }

        public void RestartGameState()
        {
            IsGameOver = false;
            OnGameRestarted?.Invoke();
        }
    }
}

