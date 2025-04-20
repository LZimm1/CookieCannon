using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject skipButton;

    private float xPos;
    private float yPos;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text cookieCountText;
    private static int indicatedCookieCount;

    [SerializeField]
    private Text lastScoreText;
    [SerializeField]
    private Text highScoreText;

    private static int highScore = -1;
    // Start is called before the first frame update
    void Start()
    {
        if(skipButton){
            xPos = skipButton.transform.position.x;
            yPos = skipButton.transform.position.y;
        }
        if(cookieCountText){
            updateCookieCount();
        }
        if(lastScoreText){
            lastScoreText.text = "Last: " + string.Format("{0:#,###0}",GameManager.level);
        }
        if(highScoreText){
            if(highScore < GameManager.level||highScore==-1){
               highScore = GameManager.level;
            }
            
            highScoreText.text = "Best: " + string.Format("{0:#,###0}",highScore);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.cookieCount > 0&&skipButton){
            skipButton.transform.position = new Vector3(100f,0f,0f);
        }
        else if(cookie.moveSpeed <= 10&&skipButton){
            skipButton.transform.position = new Vector3(xPos,yPos,0f);
        }
        if(scoreText){
            scoreText.text = string.Format("{0:#,###0}",GameManager.level);
        }
        if(cookieCountText){
            cookieCountText.text = string.Format("{0:#,###0}",indicatedCookieCount);
        }
        
    }
    public void Skip(){
        cookie.moveSpeed = 100f;
        skipButton.transform.position = new Vector3(100f,0f,0f);
    }
    public static void updateCookieCount(){
        indicatedCookieCount = GameManager.cookieCount;
    }
    public void restart(){
        GameManager.level = 0;
        GameManager.cookieCount = 1;
        SceneManager.LoadScene("Game");
    }
}
