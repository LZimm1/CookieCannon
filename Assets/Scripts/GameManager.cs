using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static int cookieCount = 1;
    [SerializeField] 
    private GameObject cookiePrefab;
    [SerializeField]
    private GameObject cookieLauncherRef;
    private static GameObject cookieRef;
    public static bool shootCookiesBool = false;
    public static bool firing=false;
    public static int level = 0;

    public static int cookiesInPlay = 0;

    public static int cookiesCollected = 0;

    public static int extraCookies;

    public static bool gameOver;
    public static bool gameOverLoading;


    // Start is called before the first frame update
    void Start()
    {
         if(instance == null){
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(shootCookiesBool){
            firing = true;
            StartCoroutine(shootCookies());
            
        }
        if(cookieCount > 999){
            cookieCount = 999;
        }
        if(level > 999999999){
            level = 999999999;
        }
        nextLevel();
        if(gameOver){
            Destroy(cookieLauncherRef);
            gameOver = false;
            StartCoroutine(gameOverFn());
        }
        if(!cookieLauncherRef){
            cookieLauncherRef = GameObject.FindWithTag("cookieLauncher");
        }
    }
    
    public IEnumerator shootCookies(){

        shootCookiesBool = false;
        if(!(gameOver||gameOverLoading)){
            Vector3 dirRef = cookieLauncher.direction;
            cookieLauncher.direction = Vector3.zero;
            while(cookieCount > 0){
                cookieRef = Instantiate(cookiePrefab);
                cookieRef.transform.position = new Vector3(cookieLauncherRef.transform.position.x, cookieLauncherRef.transform.position.y,cookieLauncherRef.transform.position.z);
                cookieRef.GetComponent<Rigidbody2D>().AddForce(-dirRef);
                cookieCount--;
                cookiesInPlay++;
                yield return new WaitForSeconds(0.1f);
            }
            firing=false;
        }


    }

    void nextLevel(){
        if(cookieCount == 0 && cookiesInPlay == 0){
            jarSpawner.spawnBlocksBool = true;
            cookieCount = cookiesCollected + extraCookies;
            UIScript.updateCookieCount();
            extraCookies = 0;
            cookiesCollected = 0;
            cookie.moveSpeed = 10f;
            if(cookie.firstCookie){
                cookieLauncherRef.transform.position = new Vector3(cookie.firstCookie.position.x, cookieLauncherRef.transform.position.y, 0f);
            }
            level++;
        }
    }
    IEnumerator gameOverFn(){
        gameOverLoading = true;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("RestartMenu");
        gameOverLoading = false;
    }
    
}
