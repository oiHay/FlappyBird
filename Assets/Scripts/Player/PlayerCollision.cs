using Manager;
using UnityEngine;

namespace Player
{
    public class PlayerCollision : MonoBehaviour
    {
        [Header("Components References")]
        [SerializeField] private PlayerController playerController;
        
        [Header("Death Settings")]
        [SerializeField] private float timeDestruction;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Wall"))
            {
                return;
            }
            
            playerController.enabled = false;
            GameManager.Instance.GameOver();
            Destroy(gameObject, timeDestruction);
        }
    }
}

