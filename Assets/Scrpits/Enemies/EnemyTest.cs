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
    [SerializeField] LayerMask losFocus;
    [SerializeField] Transform aimingThing;

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
        RaycastHit2D ray = Physics2D.Raycast(transform.position, target.position - transform.position, Vector2.Distance(target.position, rb.position), losFocus); //shoot a ray att the target
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.gameObject.name == "Player"; //if it hits the player we have line of sight
            if (hasLineOfSight)
            {
                Debug.DrawRay(transform.position, target.position - transform.position, Color.blue); //draw a blue ray if ghost has line of sight
            }
            else
            {
                Debug.DrawRay(transform.position, target.position - transform.position, Color.red); //draw a red ray if otherwise
            }
        }

        print(ray.collider.gameObject.name);
        if (Vector2.Distance(transform.position, target.position) > targetDistance && !hasLineOfSight)
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
        if(Vector2.Distance(transform.position, target.position) > targetDistance && !hasLineOfSight)
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

    void AimFireball()
    {
        Vector3 look = transform.InverseTransformPoint(target.position);
        float Angle = Mathf.Atan2(look.y, look.y) * Mathf.Rad2Deg - 90;

        aimingThing.Rotate(0, 0, Angle);
    }
}
