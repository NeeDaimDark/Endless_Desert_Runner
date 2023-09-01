using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectableControl : MonoBehaviour
{
    public TextMeshProUGUI coinCountDisplay;
    public static int coinCountInt = 0;
    
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        //display coins collected
        coinCountDisplay.SetText("" + coinCountInt.ToString());
    }
}
