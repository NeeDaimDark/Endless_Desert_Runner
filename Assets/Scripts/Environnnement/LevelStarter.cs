using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
    
{

    public GameObject CountDown3;
    public GameObject CountDown2;
    public GameObject CountDown1;
    public GameObject CountDownGo;
    public GameObject fadeIn;


    // Start is called before the first frame update
  
    void Update()
    {
        StartCoroutine(CountSequence());

    }

    IEnumerator CountSequence()
    {
        yield return new WaitForSeconds(1.5f);
        CountDown3.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown2.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown1.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDownGo.SetActive(true);
    }
}