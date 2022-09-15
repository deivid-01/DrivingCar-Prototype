using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public  Transform objectFollow;
    public Vector3  offset;
    public  float followSpeed = 10;
    public float lookSpeed = 10;


    private void LookAtTarget ()
    {
        Vector3 lookDirection = objectFollow.position - this.transform.position;
        Quaternion rot = Quaternion.LookRotation ( lookDirection , Vector3.up );

        transform.rotation = Quaternion.Lerp ( this.transform.rotation , rot , lookSpeed * Time.deltaTime );
    }

    private void MoveToTarget ()
    {
        Vector3 targetPosition = objectFollow.transform.position + offset;
                               /* objectFollow.forward*offset.z+
                                objectFollow.up * offset.y+
                                objectFollow.right* offset.x;*/


        transform.position = Vector3.Lerp ( transform.position , targetPosition , followSpeed * Time.deltaTime );
    }

    private void FixedUpdate ()
    {
        LookAtTarget ();
        MoveToTarget ();
    }
}
