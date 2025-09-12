using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public float firstSpawn;
    public float cooldownResetValue;
    [HideInInspector] public float cooldown;

    public GameObject obstacle;

    private ScoreManager score_manager;

    void Start()
    {
        score_manager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        cooldown = firstSpawn;
    }

    void Update()
    {
        CooldownTimer();
    }

    void CooldownTimer()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else if (cooldown <= 0)
        {
            SpawnObstacle();
            cooldown = cooldownResetValue - (score_manager.score_ / 10);
        }
    }

    void SpawnObstacle()
    {
        Instantiate(obstacle, new Vector3(5, Random.Range(-3, 3), 0), Quaternion.identity);
    }
}
