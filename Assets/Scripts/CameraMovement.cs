using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform car;
    public Vector3 offset;

    private void Update ()
    {
        this.transform.position = car.position + offset;
    }
}
