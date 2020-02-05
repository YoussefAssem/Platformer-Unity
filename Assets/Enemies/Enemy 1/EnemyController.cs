using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed;
    private new Rigidbody rigidbody;

    private int targetIndex = 0;
    private Transform target;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        foreach (Transform child in transform.parent)
        {
            if (child.CompareTag("Waypoint"))
                waypoints.Add(child);
        }
        switchTarget();
    }

    private void switchTarget()
    {
        if (targetIndex + 1 == waypoints.Count)
            targetIndex = -1;

        targetIndex++;
        target = waypoints[targetIndex];
        transform.forward = target.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (transform.position == target.position)
            switchTarget();
        
        rigidbody.position = Vector3.MoveTowards(transform.position,target.position, moveSpeed * Time.deltaTime);
    }
}
