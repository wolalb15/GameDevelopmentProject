using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public float respawnDelay;
    public PlayerController gamePlayer;
    public int coins;
    public Text coinText;
    public HealthSysteme healthSysteme;
    public Text healthbar;

    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        healthSysteme = new HealthSysteme(100);


        coinText.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }



    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnpoint;
        gamePlayer.gameObject.SetActive(true);
        healthSysteme.setHealth(100);
        healthbar.text = "Health: " + healthSysteme.gethealth();
    }

    public void AddCoins(int numberOfCoins)
    {
        coins += numberOfCoins;
        coinText.text = "Coins: " + coins;
      
    }

    public void TakeDamage(int damage)
    {

        healthSysteme.damage(damage);
        if(healthSysteme.gethealth() == 0)
        {
            Respawn();
        }
        healthbar.text = "Health: " + healthSysteme.gethealth();       
    }



}
