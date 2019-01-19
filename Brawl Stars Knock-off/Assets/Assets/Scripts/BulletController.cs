using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Bullets move forward in straight line, stay on screen for max timeUntilDisappear seconds

public class BulletController : MonoBehaviour {

    public float speed;
    public int timeUntilDisappear;

    private Rigidbody rb;

    private float timeCreated;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        timeCreated = Time.time;
	}
	
	void Update () 
    {
        if (Time.time - timeCreated > timeUntilDisappear)
        {
            Destroy(this.gameObject);
        }
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
	}

}
