using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class LevelDistance : MonoBehaviour
{
    public TextMeshProUGUI distanceCountDisplay;
    public static int distanceCountInt = 0;
    public static bool addingDistance=false;
    public float disDelay=0.35f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        //check if tistance is not added and add distance every 0.35 seceonds 
        if (addingDistance == false)
        {
            if (PlayerMovement.canMove)
            {
                addingDistance = true;
                StartCoroutine(AddingDis());

            }
        }
    }
    
    //this method count distance runned and display it every 0.35 second 
    IEnumerator AddingDis()
    {
        distanceCountInt++;
        distanceCountDisplay.SetText("" + distanceCountInt.ToString());
        yield return new WaitForSeconds(disDelay);
        addingDistance = false;
    }
}
