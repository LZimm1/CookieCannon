using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jar : MonoBehaviour
{
    [SerializeField]
    private Text healthText;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = (int)(Random.Range(GameManager.level,GameManager.level*2f)+0.5f);
        if(GameManager.level == 0){
            health = (int)(Random.Range(1f,2f)+0.5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(healthText){
            if(health>999){
                health = 999;
            }
            healthText.text = health.ToString();
            if(health<20){
                healthText.color = Color.Lerp(Color.white,Color.red,health/20f);
            }
            else if(health<35){
                healthText.color = Color.Lerp(Color.red,Color.magenta,(health%20)/15f);
            }
            else if(health<55){
                healthText.color = Color.Lerp(Color.magenta,Color.cyan,(health%35)/20f);
            }
            else if(health<70){
                healthText.color = Color.Lerp(Color.cyan,Color.green,(health%55)/15f);
            }
            else if(health<85){
                healthText.color = Color.Lerp(Color.green,Color.blue,(health%70)/15f);
            }
            else if(health<100){
                healthText.color = Color.Lerp(Color.blue,Color.black,(health%85)/15f);
            }
            else{
                healthText.color = Color.black;
            }
            
            
            if(health <= 0){
                Destroy(gameObject);
            }
        }


    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("cookie")){
            health--;
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("gameEndCollider")){
            GameManager.gameOver = true;
        }
    }

    
}
