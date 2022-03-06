using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private const float MOVE_SPEED = 5f;

    private Rigidbody2D rb; 
    private Vector3 moveDir;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){

        float moveX = 0f;
        float moveY = 0f;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)){
           moveY = +1f; 
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){
           moveY = -1f; 
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
           moveX = -1f; 
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
           moveX = +1f; 
        }

        moveDir = new Vector3(moveX,moveY);
    }

    private void FixedUpdate(){
        rb.velocity = moveDir * MOVE_SPEED;
    }


}
