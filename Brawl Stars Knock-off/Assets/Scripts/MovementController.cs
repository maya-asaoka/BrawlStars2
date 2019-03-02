using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    public GameObject playerBulletPrefab;

    public float speed = 0.5f;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward;
        Vector3 move = new Vector3(x * speed * forward.x, 0, y * speed * forward.y);


        //rb.MovePosition(rb.position + move);

        // x direction
        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(rb.position + transform.forward * speed);
        }
        else if (Input.GetKey(KeyCode.S)){
            rb.MovePosition(rb.position + (-transform.forward * speed));
        }


        if (Input.GetKey(KeyCode.A))
        {
            Vector3 left = new Vector3(-forward.z, 0, forward.x);
            rb.MovePosition(rb.position + left * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 right = new Vector3(forward.z, 0, -forward.x);
            rb.MovePosition(rb.position + (right * speed));
        }


       
        if (Input.GetButtonDown("Fire1")) {
             GameObject projectile = Instantiate(playerBulletPrefab) as GameObject;
             projectile.transform.position = transform.position + Camera.main.transform.forward *2;
             Rigidbody rb = projectile.GetComponent<Rigidbody>();
             rb.velocity= Camera.main.transform.forward * 40;
             }

    }
}
