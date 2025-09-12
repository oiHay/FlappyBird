using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private ScoreManager score_manager;

    void Start()
    {
        score_manager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limiter"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("PointCounter"))
        {
            score_manager.score_++;
        }
    }
}
