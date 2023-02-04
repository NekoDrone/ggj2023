using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class char1control : MonoBehaviour
{
    [SerializeField] private int DistanceToGround = 0;
    Ray2D groundTest;
    Rigidbody2D char1rb = new Rigidbody2D();
    [SerializeField] private float JumpHeight = 0f;
    Vector2 jumpdir;

    void Start()
    {
        Transform trfm = GetComponent<Transform>();
        char1rb = GetComponent<Rigidbody2D>();
        jumpdir = new Vector2(0,1*JumpHeight*100);
        groundTest.direction = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(groundTest.origin, groundTest.direction * DistanceToGround, Color.magenta);
        groundTest.origin = transform.position;
        if(Input.GetKeyDown(KeyCode.Space) && IsGroundedCheck()){
            Debug.Log("I have jumped!");
            DoAJump();
        }
    }

    bool IsGroundedCheck(){
        Debug.Log("Ground check has been triggered.");
        RaycastHit2D hit;
        try{
            hit = Physics2D.Raycast(groundTest.origin, groundTest.direction, DistanceToGround);
            Debug.Log(hit.collider.gameObject.name);
            return hit.collider.gameObject.name == "Floor";
        }
        catch (NullReferenceException){
            Debug.Log("Char1 is not touching the ground.");
            return false;
        }
    }
    
    void DoAJump(){
        char1rb.AddForce(jumpdir);
        Debug.Log("Char 1 jumped.");
    }
}
