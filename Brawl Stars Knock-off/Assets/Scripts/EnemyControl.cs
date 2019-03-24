using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject player; 
    private float turnSpeed = 1f; 
    private float speed = 2f; 
    private float playerRadius = 2f; 

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.gameObject.transform.position;
        Vector3 followPlayer = playerPos - transform.position; 
        Vector3 rotationDirection = Vector3.RotateTowards(transform.forward, followPlayer, turnSpeed * Time.deltaTime, 0.0f);
        rb.MoveRotation(Quaternion.LookRotation(rotationDirection));

        if (Vector3.Distance(transform.position, playerPos) > playerRadius)
        {
            Vector3 moveTowardsPlayer = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            rb.MovePosition(moveTowardsPlayer);
        }
    }
}
