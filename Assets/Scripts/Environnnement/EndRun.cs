using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRun : MonoBehaviour
{
    public GameObject liveCoins;
    public GameObject liveDistance;
    public GameObject endScreen;
    public GameObject fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EndSecquence());
    }

    IEnumerator EndSecquence()
    {
        yield return new WaitForSeconds(5);
        // faire disparitre cout coins and distance 
        liveCoins.SetActive(false);
        liveDistance.SetActive(false);
        //faire apparaitre menu game over
        endScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        //Rendre l'ecran noir 
        fadeOut.SetActive(true);
        //aller au menu principal
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);



    }
}
