using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    [SerializeField] private AudioClip ballHit,death,buttonUI;
    [SerializeField] private AudioSource audioSource_soundEffectsController;


    public void BallHit_soundEffect(){
        audioSource_soundEffectsController.PlayOneShot(ballHit);
    }

    public void Death_soundEffect(){
        audioSource_soundEffectsController.PlayOneShot(death);

    }

    public void ButtonUI_soundEffect(){
        audioSource_soundEffectsController.PlayOneShot(buttonUI);

    }
}
