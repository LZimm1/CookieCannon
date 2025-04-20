using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jarSpawner : MonoBehaviour
{

    private float yPos = 3.45f;
    private float xPos = -2.961334f+0.02800137f;

    [SerializeField]
    private GameObject jar;

    private GameObject jarRef;

    [SerializeField]
    private GameObject extraCookie;

    private GameObject extraCookieRef;

    public static bool spawnBlocksBool = false;

    [SerializeField]
    private GameObject jarParent;
    // Start is called before the first frame update
    void Start()
    {
        spawnBlocks();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnBlocksBool){
            spawnBlocks();
        }
    }
    public void spawnBlocks(){
        spawnBlocksBool = false;
        xPos = -2.961334f+0.02800137f;
        for(int i = 0; i < 9;i++){
            float x = Random.Range(0f,1f);
            if(x>0.625f){
                jarRef = Instantiate(jar, jarParent.transform);
                jarRef.transform.position = new Vector3(xPos, yPos,0f);
            }
            else if(x<0.085f && GameManager.extraCookies < 999){
                extraCookieRef = Instantiate(extraCookie,jarParent.transform);
                extraCookieRef.transform.position = new Vector3(xPos,yPos,0f);
            }

            xPos+=1.1f/1.5f;
        }
        jarParent.transform.position = new Vector3(jarParent.transform.position.x, jarParent.transform.position.y-1f/1.5f, 0f);
    }
}
