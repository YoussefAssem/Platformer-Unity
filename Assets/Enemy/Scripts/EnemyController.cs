using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed;

    private int targetIndex = 0;
    private Transform target;

    private void Awake()
    {
        foreach (Transform child in transform.parent)
        {
            if (child.CompareTag("Waypoint"))
                waypoints.Add(child);
        }
        SwitchTarget();
    }

    private void SwitchTarget()
    {
        if (targetIndex + 1 == waypoints.Count)
            targetIndex = -1;

        targetIndex++;
        target = waypoints[targetIndex];
        transform.forward = target.position - transform.position;
    }

    private void Update()
    {
        if (transform.position == target.position)
            SwitchTarget();
        
        transform.position = Vector3.MoveTowards(transform.position,target.position, moveSpeed * Time.deltaTime);
    }
}
