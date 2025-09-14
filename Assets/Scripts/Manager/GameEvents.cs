using UnityEngine;

public class GameEvents : MonoBehaviour
{
    private GameObject player;
    private PlayerBehavior playerBehavior;

    void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerBehavior = player.GetComponent<PlayerBehavior>();
            }
        }

        if (playerBehavior != null && player != null)
        {
            if (!playerBehavior.isAlive)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        else
        {
            Time.timeScale = 0f;
        }
    }
}
