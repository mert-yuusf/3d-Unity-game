using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Config Movement")]
    public float Speed=100;
    public float JumpForce;
    [SerializeField] private Rigidbody playerRb;
    public ParticleSystem moveEffect;
    private Vector3 playerPosition;
    [Header("Ground Checker")]
    public Transform checkGroundPoint;
    public float groundRadius;
    public LayerMask WhereIsGround;
    public bool isOnGround;

    

    private void Update()
    {
        isOnGround = Physics.CheckSphere(checkGroundPoint.position, groundRadius, WhereIsGround);
        
        if (isOnGround && Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.velocity = Vector3.up * JumpForce;
        }

        if(transform.position.y < 0)
        {
            var gameManager = FindObjectOfType<GameManager>();
            gameManager.gameOver = true;
            gameManager.GameOver();
        }
    }
    private void FixedUpdate()
    {
        // move player when input x or y
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        playerPosition = new Vector3(horizontal, 0f, vertical);
        if (horizontal != 0 || vertical != 0)
        {
            playerRb.velocity = playerPosition + transform.forward * Speed * Time.fixedDeltaTime;
            moveEffect.Play();
        }
        // stop move effect when speen is zero
        if(playerRb.velocity.x == 0)
        {
            moveEffect.Stop();
        }
        
        var relative = (transform.position + playerPosition) - transform.position;
        var rot = Quaternion.LookRotation(relative, Vector3.up);
        transform.rotation = rot;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
    }

}
