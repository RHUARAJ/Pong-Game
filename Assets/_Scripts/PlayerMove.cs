using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private HUDController hUDController;
    private RectTransform rectTransform;
    private float speed = 300f;
    Vector2 newVelocity;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update

    public float Speed{
        set{
            speed = value;
        }

        get{
            return speed;
        }
    }
    void Start()
    {
        if(hUDController){
            float _speed = hUDController.PlayerSpeed;

            if(_speed != 0.0f){
                Speed = _speed;
            }
        }else print("Please Attach HUDController To Player");
        rectTransform = GetComponent<RectTransform>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float yMove = Input.GetAxis("Vertical");

        yMove *= speed;

        newVelocity = new Vector2(0f,yMove);

       

        
    }


    private void FixedUpdate() {
        if(rigidbody2D)
        rigidbody2D.velocity = newVelocity;
    }

    
}
