using UnityEngine;
using Random = UnityEngine.Random;

namespace Manager
{
    public class ObstacleManager : MonoBehaviour
    {
        [Header("Obstacle Components References")] 
        [SerializeField] private GameObject obstaclePrefab;
        
        private float initialCoolDown;
        private float coolDown;
        private bool canSpawn;

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
            initialCoolDown = (3 - (ScoreManager.Score / 10f));
            coolDown = initialCoolDown;
            canSpawn = true;
        }
        
        private void Update()
        {
            if (!canSpawn)
            {
                return;
            }
            
            SpawnTimer();
        }

        private void SpawnTimer()
        {
            if (coolDown <= 0)
            {
                SpawnObstacle();
                coolDown = initialCoolDown;
                return;
            }
            
            coolDown -= Time.deltaTime;
        }
        
        private void SpawnObstacle()
        {
            Instantiate(obstaclePrefab, new Vector3(5,Random.Range(-3,3),0), Quaternion.identity);
        }
        
        private void HandleGameOver()
        {
            canSpawn = false;
        }
        
        private void HandleGameRestarted()
        {
            canSpawn = true;
            coolDown = initialCoolDown;
        }
    }
}

