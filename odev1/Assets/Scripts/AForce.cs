using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AForce : MonoBehaviour
{
    //apply force to planet through z axis just one time

    //force can be changed thoughtout in the editor

    public float force = 5;
    public bool forceX = false;
    public bool forceY = false;
    public bool forceZ = false;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //if forceX is true, apply force to planet through x axis
        if (forceX == true)
        {
            rb.AddForce(transform.right * force);
        }
        //if forceY is true, apply force to planet through y axis
        if (forceY == true)
        {
            rb.AddForce(transform.up * force);
        }
        //if forceZ is true, apply force to planet through z axis
        if (forceZ == true)
        {
            rb.AddForce(transform.forward * force);
        }

        Debug.Log("Force applied");
    }
}
