using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy AI")]
    [SerializeField] private Rigidbody emenyRb;
    [SerializeField] private float speed;
    [SerializeField] private bool xPositive;

    // Update is called once per frame
    void Update()
    {
        
        if (xPositive)
        {
            emenyRb.velocity = Vector3.right * speed;
        }
        else
        {
            emenyRb.velocity = Vector3.right * -speed;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Wall")
        {
            xPositive = !xPositive;
        }
        if(collision.collider.name == "Player")
        {
            var gameManager = FindObjectOfType<GameManager>();
            gameManager.gameOver = true;
            gameManager.GameOver();
        }
    }
}
