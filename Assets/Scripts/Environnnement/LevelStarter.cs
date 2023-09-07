using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelStarter : MonoBehaviour
    
{

    public GameObject CountDown3;
    public GameObject CountDown2;
    public GameObject CountDown1;
    public GameObject CountDownGo;
    public GameObject fadeIn;
    public AudioSource readyFX;
    public AudioSource goFX;


    // Start is called before the first frame update
  
    void Start ()
    {
        
        StartCoroutine(CountSequence());

    }

    //this method is to play the coountdown and fadeIN animation using StartCoroutine() in the start method   
    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
     //active animation of 3 
     CountDown3.SetActive(true);
        //active sound ready
        readyFX.Play();
        //wait 1 second
        yield return new WaitForSeconds(1);
        CountDown2.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        CountDown1.SetActive(true);
        readyFX.Play();
        yield return new WaitForSeconds(1);
        CountDownGo.SetActive(true);
        yield return new WaitForSeconds(1);
        goFX.Play();
        //set the movement of player active when the game starts after the animations and sound effect of ready and go 
        PlayerMovement2.canMove = true;

    }
}
