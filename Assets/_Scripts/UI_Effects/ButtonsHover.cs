using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsHover : MonoBehaviour
{
    public void OnMouseHoverEnter(){
        GameObject TextObj = transform.GetChild(0).gameObject;
        if(TextObj){
            TextObj.GetComponent<Text>().color = Color.white;
        }
    }

    public void OnMouseHoverExit(){
        GameObject TextObj = transform.GetChild(0).gameObject;
        if(TextObj){
            TextObj.GetComponent<Text>().color = Color.black;
        }
    }

    public void OnMouseClick(){
        GameObject TextObj = transform.GetChild(0).gameObject;
        if(TextObj){
            TextObj.GetComponent<Text>().color = Color.black;
        }
    }
}
