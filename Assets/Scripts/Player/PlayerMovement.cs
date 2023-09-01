using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 3;
    public float leftRightSpeed = 4;
    static public bool canMove = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   //the player moves always forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)

        {  //if we press left arrow or Q we move right and it can't surpass the map left boundary
            if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
            //if we press right  arrow or D we move right and it can't surpass the map left boundary
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);

                }

            }
        }
    }
}
