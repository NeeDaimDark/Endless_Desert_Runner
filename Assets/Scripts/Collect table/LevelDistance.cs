using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class LevelDistance : MonoBehaviour
{
    public TextMeshProUGUI distanceCountDisplay;
    public static int distanceCountInt = 0;
    public bool addingDistance=false;
    public float disDelay=0.35f;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if(addingDistance==false)
        {
            addingDistance = true;
            StartCoroutine(AddingDis());
        }
    }
    IEnumerator AddingDis()
    {
        distanceCountInt++;
        distanceCountDisplay.SetText("" + distanceCountInt.ToString());
        yield return new WaitForSeconds(disDelay);
        addingDistance = false;
    }
}
