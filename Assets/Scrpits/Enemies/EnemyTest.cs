using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(Seeker))]

public class EnemyTest : Enemy
{
    [Header("Uniqe to ghost")]
    [SerializeField] float newWaypointDistance; //the desired distance from the current waypoint before chosing a new waypoint
    [SerializeField] float timeUntilNextPathUpdate = 1f; //the time until the path is updated again in seconds
    [SerializeField] LayerMask losIgnore;

    Path path; //the path the ghost will follow
    int currentWaypoint = 0;
    bool hasLineOfSight;

    Seeker seeker; //the component that finds a path to follow


    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        seeker = gameObject.GetComponent<Seeker>();

        InvokeRepeating("GeneratePath", 0f, timeUntilNextPathUpdate);
    }

    private void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, target.position - transform.position, Vector2.Distance(target.position, rb.position), losIgnore);
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.gameObject.name == "Player";
            if (hasLineOfSight && Vector2.Distance(rb.position, target.position) > targetDistance)
            {
                Debug.DrawRay(transform.position, target.position - transform.position, Color.blue);
            }
            else
            {
                Debug.DrawRay(transform.position, target.position - transform.position, Color.red);
            }
        }

        print(ray.collider.gameObject.name);
        print(Vector2.Distance(transform.position, target.position));

        if (Vector2.Distance(rb.position, target.position) > targetDistance && !hasLineOfSight)
        {
            PathToTarget();

        }
    }

    void PathToTarget()
    {
        print("Following path");
        if(path == null)
        {
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        print(direction.magnitude);
        rb.AddForce(direction * passiveSpeed);

        float distance = Vector2.Distance(path.vectorPath[currentWaypoint], rb.position);

        if(distance < newWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void GeneratePath()
    {
        if(Vector2.Distance(transform.position, target.position) > targetDistance && !hasLineOfSight && target != null)
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
}
