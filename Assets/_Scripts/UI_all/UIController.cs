using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text EnemyText,PlayerText;
    [SerializeField] private HUDController hUDController;





    public void PlayerScoreTxt(int score){
        if(PlayerText){
            if(hUDController.POINSTOWIN != 0)
            PlayerText.text = ""+hUDController.POINSTOWIN+" : "+score.ToString();
            else
            PlayerText.text = "3 : "+score.ToString();
        }
    }


    public void EnemyScoreTxt(int score){
        if(EnemyText){

            if(hUDController.POINSTOWIN != 0)
            EnemyText.text = ""+hUDController.POINSTOWIN+" : "+score.ToString();
            else
            EnemyText.text = "3 : "+score.ToString();
             
        }
    }
}
