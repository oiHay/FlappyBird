using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limiter"))
        {
            Destroy(gameObject);
        }
    }
}
