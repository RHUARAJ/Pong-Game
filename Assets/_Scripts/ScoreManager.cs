using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private UIController uIController;
    [SerializeField] private HUDController hUDController;
    [SerializeField] private GameObject ResultUI;
    private int TotalPoints = 3;
    int enemyScore=0,playerScore=0;


    


    public void SetScore(string whoWin)
    {

        if(whoWin == "Enemy"){
            enemyScore++;

            if(uIController){
                uIController.EnemyScoreTxt(enemyScore);
            }
        }

        if(whoWin == "Player"){
            playerScore++;

            if(uIController){
                uIController.PlayerScoreTxt(playerScore);
            }
        }


        CheckPoints(enemyScore,playerScore);
    }

    public void SetPoints(int points){
        TotalPoints = points;

        uIController.EnemyScoreTxt(0);
        uIController.PlayerScoreTxt(0);
        
    }

    public void Results(string winner)
    {
        if(winner.Equals("player"))
        {
            if(ResultUI){
            ResultUI.SetActive(true);
            ResultUI.transform.GetChild(0).gameObject.transform.GetChild(0).
            gameObject.GetComponent<Text>().text = "YOU WIN";

            if(hUDController){
                hUDController.DisablePauseBtn();
            }
        }
        }
        else
        {
            if(ResultUI){
            ResultUI.SetActive(true);
            ResultUI.transform.GetChild(0).gameObject.transform.GetChild(0).
            gameObject.GetComponent<Text>().text = "YOU LOSE";
            
            if(hUDController){
                hUDController.DisablePauseBtn();
            }
        }
        }



        Time.timeScale = 0;
    }


    public void CheckPoints(int enemy,int player){
            if(enemy==TotalPoints){
                Results("enemy");

            }else if(player == TotalPoints){
                Results("player");
            }
    }

    


}
