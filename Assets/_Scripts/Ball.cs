using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    private float speed = 200f;
    private SoundEffect soundEffect_S;

    // [SerializeField] private DeathRespawn deathRespawn;
    // Start is called before the first frame update
    void Start()
    {
        //sound effect
            soundEffect_S = GameObject.Find("SoundEffectsController").GetComponent<SoundEffect>();

        HUDController hUDController = GameObject.Find("HUDController").GetComponent<HUDController>();
        if(hUDController){
            float _speed = hUDController.BallSpeed;
            if(_speed != 0.0f){
                speed = _speed;
            }
        }
        rigidbody2D=GetComponent<Rigidbody2D>();

        LunchingForce();
        // InvokeRepeating("AddingForce",5,3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LunchingForce(){
        float yMove = Random.Range(0,2) == 0 ? 1: -1;
        float xMove = Random.Range(0,2) == 0 ? 1: -1;

        rigidbody2D.velocity = new Vector2(xMove*speed,yMove*speed);

    }

    void AddingForce(){
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x*1.1f,rigidbody2D.velocity.y*1.1f);
    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.collider.CompareTag("BallEnemy")){
            soundEffect_S.Death_soundEffect();
        }else{
            soundEffect_S.BallHit_soundEffect();
        }


        if(other.collider.gameObject.CompareTag("Player")){
            AddingForce();
        }
        if(other.collider.CompareTag("BallEnemy")){
            ScoreManager scoreManager = GameObject.Find("_ScoreManager").GetComponent<ScoreManager>();

            if(other.collider.gameObject.name == "EnemyWall"){
                scoreManager.SetScore("Player");
            }

            if(other.collider.gameObject.name == "PlayerWall"){
                 scoreManager.SetScore("Enemy");
            }



            DeathRespawn deathRespawn = GameObject.Find("DeathandRespawn").GetComponent<DeathRespawn>();
            if(deathRespawn){
                deathRespawn.Death(this.gameObject);
            }
        }
    }


}
