using UnityEngine;
using System.Collections;

public class DeathZone : MonoBehaviour
{

    private Transform PlayerSpawn;
    private Animator fadeSystem;

    private void Awake()
    {
        PlayerSpawn = GameObject.FindGameObjectWithTag("Respawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(Respawn(collision));
        }
    }

    private IEnumerator Respawn(Collider2D collision)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        collision.transform.position = PlayerSpawn.position;
    }
}
