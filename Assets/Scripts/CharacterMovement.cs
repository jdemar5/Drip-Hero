using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private const float MOVE_SPEED = 5f;

    private Rigidbody2D rb; 
    private Vector3 moveDir;
    bool movingLeftRight, movingUpDown;
    GameObject sprite;
    GameObject r0, r1, r2, r3, r4, r5, r6, r7;
    int lastSprite, currentSprite, playerState;

    void Start()
    {
        sprite = GameObject.Find("PlayerSprite");
        r0 = sprite.transform.GetChild(0).gameObject;
        r1 = sprite.transform.GetChild(1).gameObject;
        r2 = sprite.transform.GetChild(2).gameObject;
        r3 = sprite.transform.GetChild(3).gameObject;
        r4 = sprite.transform.GetChild(4).gameObject;
        r5 = sprite.transform.GetChild(5).gameObject;
        r6 = sprite.transform.GetChild(6).gameObject;
        r7 = sprite.transform.GetChild(7).gameObject;
        r1.SetActive(true);
        lastSprite = 0;
        currentSprite = 0;
    }

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){

        float moveX = 0f;
        float moveY = 0f;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
           moveY = +1f;
           if (!movingLeftRight)
           {
               ChangeSprite(6);
           }
           movingLeftRight = true;
           playerState = 0;
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
           moveY = -1f;
           if (!movingLeftRight)
           {
               ChangeSprite(5);
           }
           movingLeftRight = true;
           playerState = 1;
        }
        else
        {
            movingLeftRight = false;
            switch (playerState)
            {
                case 0: ChangeSprite(2); break;
                case 1: ChangeSprite(1); break;
                case 2: ChangeSprite(0); break;
                case 3: ChangeSprite(3); break;
            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
           moveX = -1f;
           if (!movingUpDown)
           {
               ChangeSprite(4);
           }
           movingUpDown = true;
           playerState = 2;
        }
        else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
           moveX = +1f;
           if (!movingUpDown)
           {
               ChangeSprite(7);
           }
           movingUpDown = true;
           playerState = 3;
        }
        else
        {
            movingUpDown = false;
            switch (playerState)
            {
                case 0: ChangeSprite(2); break;
                case 1: ChangeSprite(1); break;
                case 2: ChangeSprite(0); break;
                case 3: ChangeSprite(3); break;
            }
        }

        moveDir = new Vector3(moveX,moveY);
    }

    void ChangeSprite(int i)
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
