using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{

    public float speed;
    public float distance;
    public int hp = 30;
    public Bullet bullet;
    public Transform groundCheckPoint;
    public LevelManager gameLevelManager;
    private Animator enemyAnimator;


    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        gameLevelManager = FindObjectOfType<LevelManager>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per framess
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, distance);
        if (groundInfo.collider.tag == "FallDetector" || groundInfo.collider.tag == "EnemyDetector")
        {
            if(movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;

            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
       
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector" || collision.tag == "EnemyDetector")
        {
            

        }
        if(collision.tag == "Bullet")
        {

            enemyAnimator.SetBool("IsHurt", true);
            StartCoroutine("Hurt");
            hp -= 15;
            if(hp == 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
                gameLevelManager.AddScore(100);
            }
           
        }

    }

    IEnumerator Hurt()
    {

        yield return new WaitForSeconds(1);
        enemyAnimator.SetBool("IsHurt", false);

    }
}
