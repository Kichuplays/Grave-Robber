using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
[RequireComponent(typeof(Seeker))]

public class EnemyTest : Enemy
{
    [Header("Uniqe to ghost")]
    [SerializeField] float newWaypointDistance; //the desired distance from the current waypoint before chosing a new waypoint

    Path path; //the path the ghost will follow
    int currentWaypoint = 0;
    bool reachedEndPath, hasLineOfSight;

    Seeker seeker; //the component that finds a path to follow
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        seeker = gameObject.GetComponent<Seeker>();
    }

    void PathToPlayer()
    {

    }
}
