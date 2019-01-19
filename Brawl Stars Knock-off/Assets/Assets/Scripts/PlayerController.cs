using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public GameObject playerBulletPrefab;

    public float speed;
    public float turnSpeed;

    private Rigidbody rb;

    // raise bullets slightly up off the ground
    private Vector3 raiseBullet = new Vector3(0, 1f, 0);

	
	void Start () {
        rb = GetComponent<Rigidbody> ();
	}

    // player can only move straight forward and backward, horizontal input adds torque
    private void FixedUpdate()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            Instantiate(playerBulletPrefab, transform.position + raiseBullet, transform.rotation);
        }

        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float vertical = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 movement = transform.forward * vertical * speed * Time.deltaTime;

        float torque = horizontal * turnSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0f, torque, 0f);

        rb.MoveRotation(rb.rotation * rotation);
        rb.MovePosition(rb.position + movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            GameController.instance.CollectCoin();
        }
        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
            GameController.instance.PlayerHit();
        }
    }
}
