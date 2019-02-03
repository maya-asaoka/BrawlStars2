using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -90F;
    public float maximumX = 90F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    void Update()
    {



        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);

        }
        //else if (axes == RotationAxes.MouseX)
        //{
        //    transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);

        //    print("inside X");
        //}
        //else
        //{
        //    rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        //    transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        //    print("inside Y");
        //}
    }

    void Start()
    {
        //if(!networkView.isMine)
        //enabled = false;

        // Make the rigid body not change rotation
        //if (rigidbody)
        //rigidbody.freezeRotation = true;
    }
}
