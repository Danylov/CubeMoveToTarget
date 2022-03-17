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
        if (Input.GetKeyDown(KeyCode.Space)) playerController.ClickSpace();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) playerController.TargetMouseOver(gameObject);
    }
}