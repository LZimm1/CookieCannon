using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookie : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    [SerializeField]
    public static float moveSpeed = 10;
    public static Transform firstCookie;
    [SerializeField]
    private AudioSource bounceSound;
    [SerializeField]
    private AudioSource extraCookieSound;

    private static bool playSoundBool = false;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        extraCookieSound = GameObject.FindWithTag("UIScript").GetComponent<AudioSource>();
    }

    private void Update()
    {
        rigidBody.velocity = rigidBody.velocity.normalized * moveSpeed;
        if(rigidBody.velocity.y >0 && rigidBody.velocity.y<0.1){
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, 0.1f*moveSpeed,0f);
        }
        if(rigidBody.velocity.y <0 && rigidBody.velocity.y>-0.1){
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, -0.1f*moveSpeed,0f);
        }
        if(rigidBody.velocity.y == 0&&rigidBody.velocity.magnitude > 0){
            rigidBody.velocity = new Vector3 (rigidBody.velocity.x, -0.1f*moveSpeed, 0f);
        }
        if(playSoundBool){
            playSoundBool = false;
            if(extraCookieSound){
                extraCookieSound.Play();
            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("collector")){
            GameManager.cookiesInPlay--;
            GameManager.cookiesCollected++;
            if(GameManager.cookiesCollected == 1){
                firstCookie = GameObject.FindWithTag("firstCookie").transform;
                firstCookie.position = new Vector3(transform.position.x,0f,0f);
            }
            Destroy(gameObject);
            
        }
        if(collision.gameObject.CompareTag("jar")){
            if(bounceSound){
                bounceSound.Play();
            }
        }
        
        
    }
    public static void playSound(){
        playSoundBool = true;
    }

    
}
