using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Coins spin in place

public class CoinController : MonoBehaviour {

    public float spinSpeed;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // spin the coin
    private void FixedUpdate()
    {
        float torque = spinSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(torque, 0f, 0f);

        rb.MoveRotation(rb.rotation * rotation);
    }

}
