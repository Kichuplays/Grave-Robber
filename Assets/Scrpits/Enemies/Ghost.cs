using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(Seeker))]
[RequireComponent(typeof(CircleCollider2D))]

public class Ghost : Enemy
{
    [Header("Uniqe to ghost")]
    [SerializeField] float newWaypointDistance; //the desired distance from the current waypoint before chosing a new waypoint
    [SerializeField] float timeUntilNextPathUpdate = 1f; //the time until the path is updated again in seconds
    [SerializeField] LayerMask losFocus;
    [SerializeField] Transform aimingThing;
    [SerializeField] float fireRate;
    [SerializeField] float shootingOffset;
    [SerializeField] GameObject fireBallPreFab;
    [SerializeField] float fireBallSpeed;

    Path path; //the path the ghost will follow
    int currentWaypoint = 0;
    float fireCountUpp; //the thing that counts upp before ghost shoots
    bool hasLineOfSight;
    bool needToPath; //checks if the ghost has to move

    Seeker seeker; //the component that finds a path to follow
    Animator fireBallAnimator;
    SpriteRenderer fireBallRenderer;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        seeker = gameObject.GetComponent<Seeker>();
        fireBallAnimator = aimingThing.GetComponent<Animator>();
        fireBallRenderer = aimingThing.GetComponent<SpriteRenderer>();

        fireBallAnimator.enabled = false;

        InvokeRepeating("GeneratePath", 0f, timeUntilNextPathUpdate);
    }

    private void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, target.position - transform.position, Vector2.Distance(target.position, rb.position), losFocus); //shoot a ray att the target
        if (ray.collider != null)
        {
            hasLineOfSight = ray.collider.gameObject.name == target.gameObject.name; //if it hits the target we have line of sight
            if (hasLineOfSight)
            {
                Debug.DrawRay(transform.position, target.position - transform.position, Color.blue); //draw a blue ray if ghost has line of sight
            }
            else
            {
                Debug.DrawRay(transform.position, target.position - transform.position, Color.red); //draw a red ray if otherwise
            }
        }

        if (Vector2.Distance(transform.position, target.position) < targetDistance && hasLineOfSight == true)
        {
            fireBallAnimator.SetFloat("FireCountUpp", fireCountUpp);
            needToPath = false;
            fireCountUpp += Time.deltaTime;
            if (fireCountUpp > fireRate)
            {
                ShootFireBall();
                fireCountUpp = 0;
            }

            if (fireBallAnimator.enabled == false)
            {
                fireBallAnimator.enabled = true;
                fireBallRenderer.enabled = true;
            }
        }
        else
        {
            if (fireBallAnimator.enabled == true)
            {
                fireBallAnimator.enabled = false;
                fireBallRenderer.enabled = false;
            }

            needToPath = true;
            PathToTarget();
            if (fireCountUpp != 0)
            {
                fireCountUpp = 0;
            }
        }
    }

    void PathToTarget()
    {
        print("Following path");
        if (path == null)
        {
            return;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        rb.AddForce(direction * chaseSpeed);

        float distance = Vector2.Distance(path.vectorPath[currentWaypoint], rb.position);

        if (distance < newWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    void GeneratePath()
    {
        if (needToPath)
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

    void ShootFireBall()
    {
        Vector3 look = transform.InverseTransformPoint(target.position);
        float angle = Mathf.Atan2(look.y, look.x) * Mathf.Rad2Deg - 90;

        aimingThing.Rotate(0, 0, angle);

        GameObject fireBall = Instantiate(fireBallPreFab, rb.position, aimingThing.rotation);
        fireBall.GetComponent<FireBall>().damage = damage;
        fireBall.GetComponent<Rigidbody2D>().AddForce(fireBall.transform.up * fireBallSpeed);

        aimingThing.Rotate(0, 0, -angle);
        

        print("FIRE BALL MADA FUCKA");
    }
}
