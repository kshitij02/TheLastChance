using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    private GameController gameController;
    public bool gameOver;
    public bool isLowEnough=true;
    private MoveLeftX moveLeftScript;
    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    public int count_Collision= 0;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip jumpSound;
    public float repeatHeight;
    private bool inTouchGround=false;
    private bool inTouchRoof=false;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb=GetComponent<Rigidbody>();
        repeatHeight = GetComponent<BoxCollider>().size.y;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        transform.GetComponent<Renderer>().material.color= new Color( 51/255.0f, 255/255.0f, 255/255.0f);
        // playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        // if (Input.GetKey(KeyCode.Space) && !gameOver && isLowEnough)
        // {
        //     playerRb.AddForce(Vector3.up * floatForce);
        // }
        if(!gameOver){
            if(Input.GetKey(KeyCode.W) ||Input.GetKey(KeyCode.UpArrow)) {

                Vector3 position = playerRb.transform.position;
                if(!inTouchRoof ){
                position.y+=0.1f;
                inTouchGround=false;
                }
                playerRb.transform.position = position;
            }
            if(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) {
                Vector3 position = playerRb.transform.position;
                if(position.y>=2.5f)
                if(!inTouchGround){
                position.y-=0.1f;
                inTouchRoof=false;
                }
                playerRb.transform.position = position;
                

                // playerRb.AddForce(-Vector3.up * floatForce);
            }
            // if(Input.GetKey(KeyCode.D)) {
            //     moveLeftScript.speed+=1;
            // }
            // if(Input.GetKey(KeyCode.A)) {
            
            //     moveLeftScript.speed-=1;
            // }
            

        }


        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            if(gameController.countCollision==4){
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameController.gameOver = true;
            gameOver=true;
            gameController.countCollision+=1;
            Debug.Log("Game Over!");
            // Destroy(gameObject);
            Destroy(other.gameObject);
            gameController.restartB.gameObject.SetActive(true);
            
            }
            else{
            gameController.countCollision+=1;
            // playerRb.material.SetColor("_Color", Color.red);
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            
             // playerAudio.PlayOneShot(explodeSound, 1.0f);
            // Destroy(other.gameObject);

            }
            switch(gameController.countCollision){
                case 1:transform.GetComponent<Renderer>().material.color= new Color( 51/255.0f, 255/255.0f, 246/255.0f);
                break;
                case 2:transform.GetComponent<Renderer>().material.color= new Color( 32/255.0f, 170/255.0f, 164/255.0f);
                break;
                case 3:transform.GetComponent<Renderer>().material.color= new Color( 23/255.0f, 123/255.0f, 118/255.0f);
                break;
                case 4:transform.GetComponent<Renderer>().material.color= new Color( 10/255.0f, 75/255.0f, 72/255.0f );
                break;
                // default:transform.GetComponent<Renderer>().material.color= new Color( 51, 255, 246 );
            }


        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {   if(gameController.countCollision!=0)
            gameController.countCollision-=1;
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
            switch(gameController.countCollision){
                case 0:transform.GetComponent<Renderer>().material.color= new Color( 51/255.0f, 255/255.0f, 255/255.0f);
                break; 
                case 1:transform.GetComponent<Renderer>().material.color= new Color( 51/255.0f, 255/255.0f, 246/255.0f);
                break;
                case 2:transform.GetComponent<Renderer>().material.color= new Color( 32/255.0f, 170/255.0f, 164/255.0f);
                break;
                case 3:transform.GetComponent<Renderer>().material.color= new Color( 23/255.0f, 123/255.0f, 118/255.0f);
                break;
                case 4:transform.GetComponent<Renderer>().material.color= new Color( 10/255.0f, 75/255.0f, 72/255.0f );
                break;
                // default:transform.GetComponent<Renderer>().material.color= new Color( 51, 255, 246 );
            }


        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            inTouchGround=true;
        }
        else if(other.gameObject.CompareTag("Roof"))inTouchRoof=true;

    }

}
