using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 6;
    public float maxSpeed = 15;
    public float leftRightSpeed = 4.5f;
    static public bool canMove = false;
    public bool isJumping = false;
    public bool comingDown = false;
    public GameObject playerObject;
    public Joystick joyStick;
    public Button jumpButtom;
    void Start()
    {
        jumpButtom.onClick.AddListener(jumpingggg);

    }

    // Update is called once per frame
    void Update()
    {   //the player moves always forward
        //float moveHorizontal = joyStick.Horizontal;
        //float moveVertical = joyStick.Vertical;

        ////Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;
        ////Debug.Log("preeeeeeeesss");
        ////if (this.gameObject.transform.position.x> LevelBoundary.leftSide && this.gameObject.transform.position.x < LevelBoundary.rightSide)
        ////    {
        //    transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        //Vector3 movement = new Vector3(moveHorizontal, 0f, 0f).normalized;
       
        ////if we press left arrow or Q we move right and it can't surpass the map left boundary
        //   //if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        //   // {
    

        //    //if (movement != Vector3.zero)
        //    //{

        //           if (this.gameObject.transform.position.x > LevelBoundary.leftSide && this.gameObject.transform.position.x < LevelBoundary.rightSide)
        //       { 
        //        transform.Translate(movement * Time.deltaTime * leftRightSpeed);
           
        //         }
        //  }
        //if we press right  arrow or D we move right and it can't surpass the map left boundary
        // if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{



        //}

        // }
        float horizontalInput = joyStick.Horizontal;
    

        // The player moves always forward
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (canMove == true)
        {
            if (horizontalInput < 0)
            {
                // Joystick pushed to the left
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }
            else if (horizontalInput > 0)
            {
                // Joystick pushed to the right
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
                }
            }
            //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
            //        {




            if (isJumping == true)
            {
                if (comingDown == false)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * 7, Space.World);
                }
                if (comingDown == true)
                {
                    transform.Translate(Vector3.up * Time.deltaTime * -7f, Space.World);

                }
            }



        }
    }
    public void jumpingggg()
    {
        if (isJumping == false)
        {
            isJumping = true;
            playerObject.GetComponent<Animator>().Play("Jump");
            StartCoroutine(JumpSequence());

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
        if (moveSpeed < maxSpeed)
        {
            moveSpeed = moveSpeed + 0.05f;
        }
    }
  
}
