using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class extraCookieScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.CompareTag("cookie")){
            cookie.playSound();
            GameManager.extraCookies++;
            Destroy(gameObject);
        }
    }
}
