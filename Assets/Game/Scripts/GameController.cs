using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed=10.0f;
    public Button restartB;
    // public int health_count=5;
    public int countCollision=0;
    public int timer=0;
    public int scroe=0;
    public bool gameOver=false;
    // public Text textScroe;
    void Start()
    {
        // textScroe=GameObject.Find("ScroeText").GetComponent<ScroeText>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameOver)
    	   scroe++;
        

    }
    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
