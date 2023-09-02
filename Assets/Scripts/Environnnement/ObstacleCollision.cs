using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    //public AudioSource coinFX;
    public GameObject thePlayer;
    public GameObject characterModel;
    public AudioSource crushThud;
    public GameObject mainCamera;

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        //if we collde with obstacle the player stop moving forward 
        thePlayer.GetComponent<PlayerMovement>().enabled = false;
        //these bool wer set false the distance add can stop when the player crushes with an obstacle
        LevelDistance.addingDistance = false;
        PlayerMovement.canMove = false;
        //play animation of falling
        characterModel.GetComponent<Animator>().Play("Stumble Backwards");
        //play sound of falling 
        crushThud.Play();
        mainCamera.GetComponent<Animator>().enabled = true;
    }
}
