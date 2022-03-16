using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int movePlayer_x, movePlayer;
    private float currTime;
    public float moveTime = 3.0f;
    private readonly Vector3 initPlayerPos = new Vector3(0.0f, 8.0f, 0.0f);
    public Vector3 startPos, endPos;
    
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
        if (movePlayer == 10)
        {
            if (movePlayer_x == 2)
            {
                endPos = initPlayerPos;
                currTime = 0.0f;
            }
            MovePlayer();
        }
        movePlayer_x = movePlayer;
    }

    public void MovePlayer()
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
            if (movePlayer == 1) movePlayer = 2;
            if (movePlayer == 10) movePlayer = 0;
        }
    }
}