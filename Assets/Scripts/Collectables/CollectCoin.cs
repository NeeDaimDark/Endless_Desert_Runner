using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        //play sound of coin collecting
        coinFX.Play();
        //add and display coin collected 
        CollectableControl.coinCountInt++;
        this.gameObject.SetActive(false);

    }
}
