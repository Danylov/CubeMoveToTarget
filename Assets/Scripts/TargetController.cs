using System;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private PlayerController playerController;

    void Start()
    {
        playerController = player.gameObject.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (playerController.movePlayer == 2))
        {
            playerController.startPos = playerController.endPos;
            playerController.movePlayer = 10;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && (playerController.movePlayer == 0))
        {
            playerController.endPos = transform.position;
            playerController.movePlayer = 1;
        }
    }
}