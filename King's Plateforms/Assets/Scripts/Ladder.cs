using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isInRange;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            playerMovement.isClimbing = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
