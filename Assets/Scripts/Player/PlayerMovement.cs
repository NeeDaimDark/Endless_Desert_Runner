using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5;
    public float maxSpeed = 15f;
    public float leftRightSpeed = 5;
    static public bool canMove = false;

    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    public Joystick joyStick;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        //if (moveSpeed < maxSpeed)
        //{
        //    Debug.Log("+0.5");
        //    moveSpeed +=0.05f*Time.deltaTime;
        //}
        //the player moves always forward
        Debug.Log(moveSpeed);
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
             
        {
           
                //if we press left arrow or Q we move right and it can't surpass the map left boundary
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
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            {
                if(isJumping == false)
                {
                    isJumping = true;
                    playerObject.GetComponent<Animator>().Play("Jump");
                    StartCoroutine(JumpSequence()); 
                    
                }
            }
       
        
            if(isJumping == true)
        
            {
               if( comingDown == false)
               {
                transform.Translate(Vector3.up * Time.deltaTime * 7,Space.World);
               }
               if (comingDown == true)
               {
                transform.Translate(Vector3.up * Time.deltaTime * -7f, Space.World);
              
                }
        
            }
        }

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        playerObject.GetComponent<Animator>().Play("Standard Run");
        yield return new WaitForSeconds(2);
        Vector3 newPosition = transform.position;
        newPosition.y = 1.5f;
        transform.position = newPosition;
    }

}
