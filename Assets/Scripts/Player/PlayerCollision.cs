using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [Header("Components References")]
        [SerializeField] private PlayerController playerController;
        [SerializeField] private GameObject deathScreen;
        
        [Header("Death Settings")]
        [SerializeField] private float timeDestruction;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Wall"))
            {
                Debug.Log("Player hit wall");
                playerController.enabled = false;
                Destroy(this.gameObject, timeDestruction);
                
                deathScreen.SetActive(true);
            }
        }
    }
}

