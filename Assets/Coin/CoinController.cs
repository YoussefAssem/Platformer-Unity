using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] float offset;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotation;

    private bool isGoingUp;
    private Vector3 pos1;
    private Vector3 pos2;

    void Start()
    {
        pos1 = transform.position ;
        pos2 = pos1;
        pos2.y += offset;
    }

    void Update()
    {
        if (transform.position == pos1)
            isGoingUp = true;
        else if(transform.position == pos2)
            isGoingUp = false;

        if (isGoingUp)
            transform.position = Vector3.MoveTowards(transform.position, pos2, moveSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, pos1, moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.forward,rotation*Time.deltaTime);
    }
}
