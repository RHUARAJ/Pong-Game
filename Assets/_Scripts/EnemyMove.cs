using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private HUDController hUDController;

    private Rigidbody2D ballRigidbody2D;
    private Rigidbody2D rigidbody2D;
    private RectTransform rectTransform;

    private float enemyDelay = 1.5f;

    Vector2 newVector;

    bool isCollide;
    Vector3 PreviousPos;
    // Start is called before the first frame update
    void Start()
    {
        if(hUDController){
            float _delay = hUDController.EnemyDelay;

            if(_delay != 0.0f){
                enemyDelay = _delay;

                
            }
        }else print("Please Attach HUDController To Enemy");

        PreviousPos = GetComponent<RectTransform>().position;
        // print(""+PreviousPos);
        ballRigidbody2D = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        rectTransform = GetComponent<RectTransform>();


        

        
        
    }

    public void SetRigidBodyForBall(){
        ballRigidbody2D = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
    }

    public void ResetPosition(){
        this.GetComponent<RectTransform>().position = PreviousPos;
    }
    
    void Update()
    {float yMove=0;
        if(ballRigidbody2D)
         yMove = ballRigidbody2D.velocity.y/enemyDelay;

        // yMove *=enemySpeed;

        

        
            // if(!isCollide)
                newVector = new Vector2(0f,yMove);
       
    }


    private void FixedUpdate() {

        
        rigidbody2D.velocity = newVector;
    }


    // private void OnCollisionEnter2D(Collision2D other) {
    //     if(other.collider.CompareTag("Wall")){
    //         isCollide = true;
    //         newVector = new Vector2(0f,0f);
    //     }
    // }


    // public void SetCollider(bool isColl){
    //     isCollide = isColl;
    // }
}
