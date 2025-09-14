using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private ScoreManager score_manager;
    private MainMenuEvents mainMenu;

    [HideInInspector] public bool isAlive = true;

    void Start()
    {
        score_manager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        isAlive = true;

        mainMenu = GameObject.Find("MainMenu").GetComponent<MainMenuEvents>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limiter"))
        {
            isAlive = false;
            mainMenu.OnDying();
            Destroy(gameObject);
        }

        if (collision.CompareTag("PointCounter"))
        {
            score_manager.score_++;
        }
    }
}
