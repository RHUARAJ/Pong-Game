using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRespawn : MonoBehaviour
{

    bool isDead;
    [SerializeField] private GameObject ballObj,canvasObj,PosObj;
    [SerializeField] private EnemyMove enemyMoveS;
    
    public void Death(GameObject ball){
        if(ball){
            isDead = true;
            Destroy(ball);
        }
    }


    public void Respawn(){
        isDead=false;
        
        if(ballObj){
            
          GameObject temp =   Instantiate(ballObj);
          temp.transform.position = new Vector2(PosObj.transform.position.x,PosObj.transform.position.y);


          if(canvasObj){
            temp.transform.SetParent(canvasObj.transform);


            if(enemyMoveS){
               enemyMoveS.SetRigidBodyForBall();
               enemyMoveS.ResetPosition();
            }
          }




        }
    }

    void Update(){
        if(isDead){
            Respawn();
        }
    }
}
