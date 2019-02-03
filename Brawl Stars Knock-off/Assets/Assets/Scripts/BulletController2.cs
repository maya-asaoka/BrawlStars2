using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController2 : MonoBehaviour
{
    public float speed = 1F;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(rb.position + transform.forward * speed);
   
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
        print("Destroyed");
    }
}
