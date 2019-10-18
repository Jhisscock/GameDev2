using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector3 lastPos;
    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(!Collision.onTop){
                rb.transform.Translate(0f , 1f, 0f);
            }
        }else if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(!Collision.onGround){
                rb.transform.Translate(0f , -1f, 0f);
            }
        }else if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(!Collision.onRightWall){
                rb.transform.Translate(1f , 0f, 0f);
            }
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(!Collision.onLeftWall){
                rb.transform.Translate(-1f , 0f, 0f);
            }
        }
    }
}
