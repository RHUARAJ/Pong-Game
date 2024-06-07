using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;

public class HUDController : MonoBehaviour
{
    // ************************** PlayUI **********************************
    [SerializeField] private GameObject mainCanva;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameObject soundeffect,soundmusic;
    public void PlayBtn(){
        if(mainCanva)
        {
            Time.timeScale = 1;
            mainCanva.SetActive(true);
            transform.GetChild(1).gameObject.SetActive(false);
        }
    }


    public void CreditsBtn(){
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        
    }
    public void SettingsBtn(){
        transform.GetChild(4).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);

    }
    public void ExitBtn(){

        Application.Quit();

        // Check if the game is currently playing
        if (EditorApplication.isPlaying)
        {
            // Set the isPlaying property to false to stop playing
            EditorApplication.isPlaying = false;
        }
        
    }


    public void MainMenu(GameObject CurrectActivePanel){
            if(CurrectActivePanel){
                CurrectActivePanel.SetActive(false);
                transform.GetChild(1).gameObject.SetActive(true);
            }
    }


    public void Resume(){
        Time.timeScale = 1;
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void MainMenu(){
        
        // Application.LoadLevel(0);
        SceneManager.LoadScene(0);
    }

    public void PauseBtn(){
        Time.timeScale = 0;
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void DisablePauseBtn(){
        GameObject.Find("PauseBtn").SetActive(false);
    }


// ************************** SettingsUI **********************************
    private float playerSpeed,ballSpeed,enemyDelay;
    public float PlayerSpeed{
        set{
            playerSpeed = value;
        }

        get{
            return playerSpeed ;
        }
    }

    public float BallSpeed{
        set{
            ballSpeed = value;
        }
        get{
            return ballSpeed;
        }
    }

    public float EnemyDelay{
        set{
            enemyDelay = value;

        }
        get{
            return enemyDelay;
        }
    }
    public void LevelModes(Dropdown dropDown){
        // 0 easy - 1 hard - 2 impossible
        if(dropDown){
            

            
        if(dropDown.value == 1){
            // hard
            EnemyDelay = 1.3f;
            PlayerSpeed = 600f;
            BallSpeed = 300f;
            
        }else if(dropDown.value == 2){
            // impossible
            EnemyDelay = 1f;
            PlayerSpeed = 1000f;
            BallSpeed = 400f;
        }else if(dropDown.value == 0){
            // easy
            EnemyDelay = 1.5f;
            PlayerSpeed = 300f;
            BallSpeed = 200f;
        }
        }
        
    }


    private int points;
    public int POINSTOWIN{
        set{
            points = value;
        }

        get{
            return points;
        }
    }

    public void PointsToWin(InputField pointsTxt){

        if(!string.IsNullOrEmpty(pointsTxt.text)){
            int points_ = Convert.ToInt32(pointsTxt.text);
            if(points_ != 0){

                POINSTOWIN = points_;

                if(scoreManager){
                    scoreManager.SetPoints(POINSTOWIN);
                }else print("ScoreManager Missing");
        
            
       
    }

            }
        }



    public void SoundON_OFF(Toggle toggle){
        if(toggle){
            if(toggle.isOn){
                if(soundeffect&&soundmusic){
                    soundeffect.SetActive(true);
                    soundmusic.SetActive(true);
                }
            }else{
                if(soundeffect&&soundmusic){
                    soundeffect.SetActive(false);
                    soundmusic.SetActive(false);
                }
            }
        }
    }
    }

