using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float jumpSpeed = 7f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator playerAnimation;
    public Vector3 respawnpoint;
    public LevelManager gameLevelManager;
    bool isrotated = false;
    public float damageDelay = 1;
    bool facingRight = true;
 
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        respawnpoint = transform.position;
        gameLevelManager = FindObjectOfType<LevelManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        
        if (movement > 0f)
        {
            playerAnimation.SetBool("IsMoving", true);
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            if (isrotated)
            {
                transform.Rotate(0f, 180f, 0f);
                isrotated = false;
            }
            
        }
        else if(movement < 0f)
        {
            playerAnimation.SetBool("IsMoving", true);
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            if (!isrotated)
            {

                transform.Rotate(0f, 180f, 0f);
                isrotated = true;
                
            }
                
        }
        else
        {
            playerAnimation.SetBool("IsMoving", false);
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
       
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            
        }
        playerAnimation.SetBool("OnGround", isTouchingGround);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FallDetector")
        {
            Debug.Log("Beim Fallen");
            gameLevelManager.Respawn();
            
        }
        else if(collision.tag == "Checkpoint")
        {
            respawnpoint = collision.transform.position;
        }

        else if(collision.tag == "Enemy")
        {
            Debug.Log("Enemy hit");
            playerAnimation.SetBool("IsHurt", true);
            gameLevelManager.TakeDamage(20);
            StartCoroutine("Hurt");
           
        }
    }
    IEnumerator Hurt()
    {
        rigidBody.velocity = Vector2.zero;

        if (isrotated)
            rigidBody.AddForce(new Vector2(-200f, 200f));
        else
            rigidBody.AddForce(new Vector2(200f, 200f));

        yield return new WaitForSeconds(1);
        playerAnimation.SetBool("IsHurt", false);
    }
}
