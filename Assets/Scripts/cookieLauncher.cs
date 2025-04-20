using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cookieLauncher : MonoBehaviour
{
    private Vector3 endPosition;
    private Vector3 startPosition;

    [SerializeField]
    private GameObject line;
    public static Vector3 direction;
    private void Awake()
    {
        line.transform.position = new Vector3(100f,0f,0f);
    }
    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if(!GameManager.firing){
            if(Input.GetMouseButtonDown(0)){
            startDrag(worldPosition);
            }
            else if(Input.GetMouseButton(0)){
                continueDrag(worldPosition);
            }
            else if(Input.GetMouseButtonUp(0)){
                endDrag();
            }
        }

        direction.Normalize();
        if(direction.y >= -0.05||GameManager.cookiesInPlay!=0||GameManager.gameOver||GameManager.gameOverLoading){
            line.transform.position = new Vector3(100f,0f,0f);
        }
        else{
            line.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }

    }
    private void startDrag(Vector3 worldPosition){
        if(!(GameManager.gameOver||GameManager.gameOverLoading)&&GameManager.cookiesInPlay==0){
            startPosition = worldPosition;
        }
    }

    private void continueDrag(Vector3 worldPosition){
        if(!(GameManager.gameOver||GameManager.gameOverLoading)&&GameManager.cookiesInPlay==0){
            endPosition = worldPosition;
            direction = endPosition - startPosition;
            float rotationZ = (Mathf.Atan2(startPosition.y-endPosition.y, startPosition.x-endPosition.x) * Mathf.Rad2Deg)-45;
            line.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        }
    }

    private void endDrag(){
        if(!(GameManager.gameOver||GameManager.gameOverLoading)&&GameManager.cookiesInPlay==0){
            direction = endPosition - startPosition;
            direction.Normalize();
            if(direction.y <= -0.05){
                GameManager.shootCookiesBool = true;
            }
            line.transform.position = new Vector3(100f,0f,0f);
        }
    }
}
