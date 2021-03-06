using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    bool movingLeft = false, movingRight = false, movingForward = false, movingBackward = false, moving = false;
    GameObject sprite;
    GameObject r0, r1, r2, r3, r4, r5, r6, r7;
    int lastSprite, currentSprite, playerState;
    float oldX, oldY;

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
    
    void Update()
    {
        MovementCheck();
        if (movingRight)
        {
            if (!moving)
            {
                ChangeSprite(7);
            }
            oldX = transform.position.x;
            transform.position += Time.deltaTime * speed * Vector3.right;
            moving = true;
            playerState = 0;
        }
        else if (movingLeft)
        {
            if (!moving)
            {
                ChangeSprite(4);
            }
            oldX = transform.position.x;
            transform.position += Time.deltaTime * speed * Vector3.left;
            moving = true;
            playerState = 1;
        }
        else if (movingForward)
        {
            if (!moving)
            {
                ChangeSprite(6);
            }
            oldY = transform.position.y;
            transform.position += Time.deltaTime * speed * Vector3.up;
            moving = true;
            playerState = 2;
        }
        else if (movingBackward)
        {
            if (!moving)
            {
                ChangeSprite(5);
            }
            oldY = transform.position.y;
            transform.position += Time.deltaTime * speed * Vector3.down;
            moving = true;
            playerState = 3;
        }
        else
        {
            moving = false;
            switch (playerState)
            {
                case 0: ChangeSprite(3); break;
                case 1: ChangeSprite(0); break;
                case 2: ChangeSprite(2); break;
                case 3: ChangeSprite(1); break;
            }
        }
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

    void MovementCheck()
    {
        if (Input.GetKeyDown(KeyCode.D))
            movingRight = true;
        if (Input.GetKeyUp(KeyCode.D))
            movingRight = false;
        if (Input.GetKeyDown(KeyCode.A))
            movingLeft = true;
        if (Input.GetKeyUp(KeyCode.A))
            movingLeft = false;
        if (Input.GetKeyDown(KeyCode.S))
            movingBackward = true;
        if (Input.GetKeyUp(KeyCode.S))
            movingBackward = false;
        if (Input.GetKeyDown(KeyCode.W))
            movingForward = true;
        if (Input.GetKeyUp(KeyCode.W))
            movingForward = false;
    }
}
