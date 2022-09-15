using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    float horizontalInput; //Left or right
    float verticalInput; //Front or back
    float steeringAngle;


    [Header("Wheels Colliders")]
    public WheelCollider    frontRightW;
    public WheelCollider    frontLeftW;
    public WheelCollider    backRightW;
    public WheelCollider    backLeftW;
    [Space]
    [Header("Wheels Transform")]
    public Transform    frontRightT;
    public Transform    frontLeftT;
    public Transform    backRightT;
    public Transform    backLeftT;
    [Space]
    public float  maxSteerAngle = 30; //Maximum radius
    public float motorTorque = 50; // How fast we can go;


    private void FixedUpdate ()
    {
        GetInput ();
        Steer ();
        Accelerate ();
        UpdateWheelPoses ();
    }



    public void GetInput ()
    {
        horizontalInput = Input.GetAxis ( "Horizontal" );
        verticalInput = Input.GetAxis ( "Vertical" );
    }

    public void Steer ()
    {
        steeringAngle = maxSteerAngle * horizontalInput;
        frontLeftW.steerAngle = steeringAngle;
        frontRightW.steerAngle = steeringAngle;
    }

    public void Accelerate()
    {
        frontRightW.motorTorque = verticalInput * motorTorque;
        frontLeftW.motorTorque = verticalInput * motorTorque;
    }

    public void UpdateWheelPoses () //How it looks wheels
    {
        UpdateWheelPose ( frontRightW , frontRightT );
        UpdateWheelPose ( frontLeftW , frontLeftT );
        UpdateWheelPose ( backRightW , backRightT );
        UpdateWheelPose ( backLeftW , backLeftT );


    }

    public void UpdateWheelPose ( WheelCollider collider , Transform transform )
    {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;

        collider.GetWorldPose ( out pos , out quat );

        transform.position = pos;
        transform.rotation = quat;
    }
}
