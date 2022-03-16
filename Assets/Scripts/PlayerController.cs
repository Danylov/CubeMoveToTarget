using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int movePlayer_x = 0;
    public int movePlayer = 0;
    private float currTime = 0.0f;
    public float moveTime = 3.0f;
    private Vector3 startPos;
    public Vector3 endPos;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (movePlayer == 1)
        {
            if (movePlayer_x == 0)
            {
                startPos = transform.position;
                currTime = 0.0f;
            }
            MovePlayerToTarget();
        }
        movePlayer_x = movePlayer;
    }

    public void MovePlayerToTarget()
    {
        if (currTime < moveTime) {
            transform.position = Vector3.Slerp(startPos, endPos, currTime/moveTime);
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            currTime += Time.deltaTime;
        }
        else
        {
            transform.position = endPos;
            transform.rotation = Quaternion.identity;
            movePlayer = 0;
        }
    }
}