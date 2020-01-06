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
    

    private bool movingRight = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per framess
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, distance);
        if (groundInfo.collider.tag == "FallDetector")
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
        if (collision.tag == "FallDetector")
        {
            

        }
        if(collision.tag == "Bullet")
        {
            hp -= 15;
            if(hp == 0)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
           
        }

    }
}
