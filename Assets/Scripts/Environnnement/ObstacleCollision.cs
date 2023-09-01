using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    //public AudioSource coinFX;
    public GameObject thePlayer;
    public GameObject characterModel;
    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        //if we collde with obstacle the player stop moving forward 
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        characterModel.GetComponent<Animator>().Play("Stumble Backwards");

    }
}
