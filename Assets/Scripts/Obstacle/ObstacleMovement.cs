using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Destroy(this.gameObject, 10);
    }

    void Update()
    {
        MoveObstacle();
    }

    void MoveObstacle()
    {
        gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
    }
}
