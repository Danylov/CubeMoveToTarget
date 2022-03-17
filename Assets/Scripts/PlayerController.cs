using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 0 - initial position, not moving; 1 - move player to 1th target; 2 - move player to 2nd target;
    // 3 - ending move player to 2nd target; 10 - come back player to initial position
    public int movePlayer_x, movePlayer;   
    private float currTime;
    public float moveTime = 3.0f;
    private Vector3 initPlayerPos;
    public Vector3 startPos, middlePos, endPos;
    public List<GameObject> Targets = new List<GameObject>(6);

    private void Start()
    {
        initPlayerPos = transform.position;
    }

    void Update()
    {
        if (movePlayer == 1)
        {
            if (movePlayer_x == 0)
            {
                startPos = initPlayerPos;
                currTime = 0.0f;
            }
            MovePlayer();
        }
        if (movePlayer == 2)
        {
            if (movePlayer_x == 1) currTime = 0.0f;
            MovePlayer();
        }
        if (movePlayer == 10)
        {
            if (movePlayer_x == 3)
            {
                startPos = endPos;
                endPos = initPlayerPos;
                currTime = 0.0f;
            }
            MovePlayer();
        }
        movePlayer_x = movePlayer;
    }

    public void MovePlayer()
    {
        if (currTime < moveTime)
        {
            var t = currTime / moveTime;
            switch(movePlayer)
            {
                case 1: transform.position = Vector3.Slerp(startPos, middlePos, t);
                    break;
                case 2: transform.position = Vector3.Slerp(middlePos, endPos, t);
                    break;
                case 10: transform.position = Vector3.Slerp(startPos, endPos, t);
                    break;
                default: transform.position = Vector3.Slerp(startPos, endPos, t);
                    break;
            }
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
            currTime += Time.deltaTime;
        }
        else
        {
            transform.rotation = Quaternion.identity;
            transform.position = movePlayer != 1 ? endPos : middlePos;
            if (movePlayer != 10) movePlayer++;
            else movePlayer = 0;
        }
    }

    public void ClickSpace()
    {
       if (movePlayer == 3)  movePlayer = 10;
    }

    public void TargetMouseOver(GameObject obj)
    {
        if (movePlayer == 0)
        {
            int clickedTargetNumber = -1;
            for (int i = 0; i < Targets.Count; i++)
            {
                if (Targets[i].name == obj.name) clickedTargetNumber = i;
            }
            middlePos = (clickedTargetNumber != 0 && clickedTargetNumber != 3) ?
                 Targets[clickedTargetNumber - 1].transform.position : 
                 Targets[clickedTargetNumber + 1].transform.position;
            endPos = obj.transform.position;
            movePlayer = 1;
        }
    }
}