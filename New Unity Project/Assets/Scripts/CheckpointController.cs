using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool checkpointReached;
    public Sprite explosion;
    private SpriteRenderer checkpointSpriteRenderer;
    public Sprite oldSprite;

    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && checkpointReached == false){
            checkpointReached = true;
            checkpointSpriteRenderer.sprite = explosion;
            
            
        }
    }
}
