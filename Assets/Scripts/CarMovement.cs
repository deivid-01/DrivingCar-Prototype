using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update

     Rigidbody rg;
    [Range(0,500)]
    public float accelerationZ;
    [Range(0,100)]

    public float accelerationX;


    void Start()
    {
        rg = this.GetComponent<Rigidbody> ();
    }

    private void FixedUpdate ()
    {
        if ( Input.GetKey ( KeyCode.W ) )
        {
            rg.AddForce (0,0,accelerationZ*Time.deltaTime);//Front
        }

        if ( Input.GetKeyDown ( KeyCode.D ) )
        {
            rg.AddForce ( accelerationX , 0 , 0 ); // Right
        }

        if ( Input.GetKeyDown ( KeyCode.A ) )
        {
            rg.AddForce ( -accelerationX , 0 , 0 ); //Left
        }

        if ( Input.GetKeyDown ( KeyCode.S ) )
        {
            rg.AddForce ( 0 , 0 , -accelerationZ ); //Backwards
        }
    }
}
