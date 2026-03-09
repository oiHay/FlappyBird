using Manager;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleMovement : MonoBehaviour
    {
        [Header("Obstacle Settings")] 
        [SerializeField] private float moveSpeed;
        [SerializeField] private float lifeTime;

        private float currentLifeTime;
        private bool isFrozen;

        private void OnEnable()
        {
            GameManager.OnGameOver += HandleGameOver;
            GameManager.OnGameRestarted += HandleGameRestarted;
        }

        private void OnDisable()
        {
            GameManager.OnGameOver -= HandleGameOver;
            GameManager.OnGameRestarted -= HandleGameRestarted;
        }

        private void Start()
        {
            currentLifeTime = lifeTime;
            isFrozen = false;
        }
        
        private void Update()
        {
            if (isFrozen)
            {
                return;
            }
            
            OnMove();
            HandleLifeTime();
        }
        
        private void OnMove()
        {
            transform.position += Vector3.left * (moveSpeed * Time.deltaTime);
        }

        private void HandleLifeTime()
        {
            currentLifeTime -= Time.deltaTime;

            if (currentLifeTime <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        private void HandleGameOver()
        {
            isFrozen = true;
        }
        
        private void HandleGameRestarted()
        {
            isFrozen = false;
        }
    }
}

