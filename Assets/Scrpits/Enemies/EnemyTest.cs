using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(Seeker))]

public class EnemyTest : Enemy
{
    [Header("Uniqe to Fire Skull")]
    [SerializeField] float newWaypointDistance = 0.2f; //the desired distance from the current waypoint before chosing a new waypoint
    [SerializeField] float timeUntilNextPathUpdate = 1f; //the time until the path is updated again in seconds
    [SerializeField] GameObject explosionPreFab;

    Path path; //the path the Fire Skull will follow
    int currentWaypoint = 0;

    Seeker seeker; //the component that finds a path to follow
    SpriteRenderer sr;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        seeker = gameObject.GetComponent<Seeker>();

        InvokeRepeating("GeneratePath", 0f, timeUntilNextPathUpdate);
    }

    private void Update()
    {
        PathToTarget();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == target.gameObject.name)
        {
            Explode();
        }
    }

    void PathToTarget()
    {
        if(path == null)
        {
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        print(direction.magnitude);
        rb.AddForce(direction * chaseSpeed);

        float distance = Vector2.Distance(path.vectorPath[currentWaypoint], rb.position);

        if(distance < newWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void GeneratePath()
    {
        if(Vector2.Distance(transform.position, target.position) > targetDistance)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete);

        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    void Explode()
    {
        GameObject explosion = Instantiate(explosionPreFab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
