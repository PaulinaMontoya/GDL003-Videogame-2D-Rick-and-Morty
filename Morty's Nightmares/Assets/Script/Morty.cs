using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Morty : MonoBehaviour{

    private Rigidbody2D rb;
    private Animator animator;
 
 //   public SceneManagement;
 
    public LayerMask maskFloor;
    public Transform testFloor;
    public float forceJump = 15f;
    public float factor = 1;
    public Text txtScore;
 
    private bool isWalking;
    private bool isFloor = true;
    private float radio = 0.07f;
    private bool jump2 = false;
    private float speed = 3f;
    private Vector2 posINI;
    private int score;
    
    void Start(){
        rb = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();
        posINI = transform.position;
        txtScore.text = "SCORE: " + score.ToString ();
    }

    void FixedUpdate(){

        isFloor = Physics2D.OverlapCircle (testFloor.position, radio, maskFloor);
        animator.SetBool ("isJumping" , !isFloor);
        
        if ( isFloor ) {
            jump2 = false;
        }

        if( transform.position.y <-30 ){
            transform.position = posINI;
        }
    }

    void Update(){
        if( Input.GetKeyDown(KeyCode.UpArrow) ){
           
           if (isFloor || !jump2){
               rb.velocity = new Vector2 (rb.velocity.x, forceJump);
               rb.AddForce (new Vector2 (0, forceJump));

               if (!jump2 && !isFloor){
                   jump2 = true;
               }    
           }
            rb.AddForce (new Vector2 (0 , forceJump));
        }

        // Caminar a la derecha
        if ( Input.GetKeyDown(KeyCode.RightArrow) ){
            animator.SetBool ("isWalking", true);
            isWalking = true;
            transform.localRotation = Quaternion.Euler (0,0,0);
            speed = 10;
            factor = 1;
        }
        // Caminar a la izquierda
        if ( Input.GetKeyDown(KeyCode.LeftArrow) ){
            animator.SetBool ("isWalking", true);
            isWalking = true;
            transform.localRotation = Quaternion.Euler (0,180,0);
            speed = -10;
            factor = 1;
        }
        if ( Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ){
            animator.SetBool ("isWalking", false);
            isWalking = false;
        }

        if ( Input.GetKeyDown(KeyCode.LeftShift) && isWalking ){
            factor = 2;
        }

        if ( Input.GetKeyUp(KeyCode.LeftShift) && isWalking ){
            factor = 1;
        }

        if (isWalking){
            rb.velocity = new Vector2 (speed * factor, rb.velocity.y);
        }
    }

    public void OnCollisionEnter2D( Collision2D obj ){
        if ( obj.transform.tag == "move" ){
            transform.parent = obj.transform;
        }
        if (obj.transform.name == "Top"){
            Destroy (obj.transform.parent.gameObject);
        }
        if (obj.transform.name == "Body"){
            Destroy (this.gameObject);
           // transform.position = posINI;
            Application.LoadLevel(2);
        } 
        if (obj.transform.tag == "diamond"){
            Destroy (obj.transform.gameObject);
            score += 1;
            txtScore.text = "SCORE: " + score.ToString();
        }
        if (obj.transform.tag == "portal"){
            // print ("Good Job Morty");
          // SceneManagement.LoadScene ("GoodJob");
          // transform.position = posINI;
          Application.LoadLevel(1);
        }
    }
    public void OnCollisionExit2D( Collision2D obj ){
        if ( obj.transform.tag == "move" ){
            transform.parent = null;
        }
    }
}
