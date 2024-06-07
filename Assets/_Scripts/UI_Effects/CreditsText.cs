using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsText : MonoBehaviour
{
    private float speed=3f;

    private void Start() {
        Time.timeScale = 1;
    }
    

    // Update is called once per frame
    void Update()
    {
        
       Vector3 currentPos = transform.position;
        Vector3 localPos = transform.TransformDirection(0,1,0);

        currentPos +=  speed * localPos * Time.deltaTime;

        transform.position = currentPos ;

    }
}
