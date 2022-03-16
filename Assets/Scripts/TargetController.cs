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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.startPos = playerController.endPos;
            playerController.movePlayer = 10;
        }
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            playerController.endPos = transform.position;
            playerController.movePlayer = 1;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) Debug.Log("Target has collided with player.");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) Debug.Log("Target has triggered with player.");
    }

}