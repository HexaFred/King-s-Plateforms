using UnityEngine;

public class EnnemiPatrol : MonoBehaviour
{
    public SpriteRenderer graphics;
    public Transform[] waypoints;
    public float speed;

    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = waypoints[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // 03f - > Ennemi presaque arrivé
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length; //Retourne au début quand derniere destination atteinte
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
}
