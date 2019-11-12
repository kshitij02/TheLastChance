using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class scroe : MonoBehaviour
{
    // Start is called before the first frame update
	private GameController gameController;
    public Text score;
    public double val;
    void Start()
    {
        gameController=GameObject.Find("GameController").GetComponent<GameController>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!gameController.gameOver){
            val=gameController.scroe*Time.deltaTime;
            score.text="Life Remaining :"+(5-gameController.countCollision).ToString()+"\n Score : "+ (Convert.ToInt32(val)-5).ToString();
        }else{
            score.text="Game Over !! "+"\nYour Score : "+ (Convert.ToInt32(val)-5).ToString();
        }
    }
}
