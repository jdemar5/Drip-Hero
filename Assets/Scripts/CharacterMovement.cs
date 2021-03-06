using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    //This class handles all the player movement as well as the sprite changes and animations
    
    //initialization
    private const float MOVE_SPEED = 8f;
    private Rigidbody2D rb; 
    private Vector3 moveDir;
    bool movingRight, movingLeft, movingForward, movingBackward, moving, switchSprite;
    GameObject sprite;
    GameObject r0, r1, r2, r3, r4, r5, r6, r7;
    int lastSprite, currentSprite, playerState;
    float moveX;
    float moveY;

    void Start()
    {
        sprite = GameObject.Find("PlayerSprite");
        //order of children very important, please do not change
        r0 = sprite.transform.GetChild(0).gameObject; //should get LeftDefault
        r1 = sprite.transform.GetChild(1).gameObject; //should get BackDefault
        r2 = sprite.transform.GetChild(2).gameObject; //should get FrontDefault
        r3 = sprite.transform.GetChild(3).gameObject; //should get RightDefault
        r4 = sprite.transform.GetChild(4).gameObject; //should get LeftWalk
        r5 = sprite.transform.GetChild(5).gameObject; //should get BackWalk
        r6 = sprite.transform.GetChild(6).gameObject; //should get FrontWalk
        r7 = sprite.transform.GetChild(7).gameObject; //should get RightWalk
        r0.SetActive(true); //setting default state, what the player will load in as
        //values will be used to switch sprite with ChangeSprite function
        lastSprite = 0;
        currentSprite = 0;
        switchSprite = false;
    }

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){

        moveX = 0f;
        moveY = 0f;

        MovementCheck();

        //logic that determines when to show running animations
        if(movingRight || movingLeft || movingForward || movingBackward)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (!moving)
        {
            switch (playerState)
            {
                case 0:
                    ChangeSprite(3); break;
                case 1:
                    ChangeSprite(0); break;
                case 2:
                    ChangeSprite(1); break;
                case 3:
                    ChangeSprite(2); break;
            }
        }
        else if (switchSprite)
        {
            switch (playerState)
            {
                case 0:
                    ChangeSprite(7); break;
                case 1:
                    ChangeSprite(4); break;
                case 2:
                    ChangeSprite(5); break;
                case 3:
                    ChangeSprite(6); break;
            }
            switchSprite = false;
        }

        moveDir = new Vector3(moveX,moveY);
    }

    void MovementCheck() //where the input is checked, needs to be called each update
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveY = +1f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveX = +1f;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            movingRight = true;
            playerState = 0;
            switchSprite = true;
        }
        if (Input.GetKeyUp(KeyCode.D))
            movingRight = false;
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
            playerState = 1;
            switchSprite = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
            movingLeft = false;
        if (Input.GetKeyDown(KeyCode.S))
        {
            movingBackward = true;
            playerState = 2;
            switchSprite = true;
        }
        if (Input.GetKeyUp(KeyCode.S))
            movingBackward = false;
        if (Input.GetKeyDown(KeyCode.W))
        {
            movingForward = true;
            playerState = 3;
            switchSprite = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
            movingForward = false;
    }

    void ChangeSprite(int i) //simple function that switches the current sprite with what is passed to it
    {
        lastSprite = currentSprite;
        currentSprite = i;
        switch (lastSprite)
        {
            case 0: r0.SetActive(false); break;
            case 1: r1.SetActive(false); break;
            case 2: r2.SetActive(false); break;
            case 3: r3.SetActive(false); break;
            case 4: r4.SetActive(false); break;
            case 5: r5.SetActive(false); break;
            case 6: r6.SetActive(false); break;
            case 7: r7.SetActive(false); break;
        }
        switch (currentSprite)
        {
            case 0: r0.SetActive(true); break;
            case 1: r1.SetActive(true); break;
            case 2: r2.SetActive(true); break;
            case 3: r3.SetActive(true); break;
            case 4: r4.SetActive(true); break;
            case 5: r5.SetActive(true); break;
            case 6: r6.SetActive(true); break;
            case 7: r7.SetActive(true); break;
        }
    }

    private void FixedUpdate(){
        rb.velocity = moveDir * MOVE_SPEED;
    }


}
