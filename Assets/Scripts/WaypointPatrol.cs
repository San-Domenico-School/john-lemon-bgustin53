/* This script is attached to the ghosts and uses the NavMesh to 
 * move the Ghosts between an assigned groups of waypoints.
 * 
 * Bruce Gustin
 * May 17, 2023
 * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypointIndex;

    // Sets the initial destination of the Ghost
    void Start()
    {
        navMeshAgent.SetDestination(waypoints[0].position);
    }

    // Moves the Ghosts between destinations
    void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}
