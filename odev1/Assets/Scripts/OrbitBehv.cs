using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitBehv : MonoBehaviour
{
    public float radius; // radius of rotation

    private float angle = 0; // angle of rotation
    public float angleSpeed = 1; // speed of rotation

    [SerializeField]
    private bool changeOrbitDirection = true; // direction of rotation

    IEnumerator orbit; // coroutine for orbit rotation process

    //choose orbit axis from radio button x,y,z

    public bool axisX = false;
    public bool axisY = true;
    public bool axisZ = false;

    //store staring positon of object
    Vector3 Pos;

    // Start is called before the first frame update
    void Start()
    {
        orbit = OrbitBehvv();
        StartCoroutine(orbit); // start coroutine
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator OrbitBehvv()
    {
        //radius equals to distance between object and (0,0,0)
        radius = Vector3.Distance(transform.position, Vector3.zero);

        while (true)
        {
            if (changeOrbitDirection) // Check rotation direction
            {
                angle += angleSpeed * Time.deltaTime; //set rotation speed
                transform.position = new Vector3(
                    Mathf.Cos(angle) * radius,
                    0,
                    Mathf.Sin(angle) * radius
                ); //rotate planet around y axis

                if (angle >= (2 * Mathf.PI))
                {
                    angle = 0; //reset angle if it reaches 2*PI (~6.28)
                    Debug.Log(transform.tag + " orbit complete"); //print orbit complete message with tag of planet
                }
            }
            else
            {
                angle -= angleSpeed * Time.deltaTime; //set rotation speed
                transform.position = new Vector3(
                    Mathf.Cos(angle) * radius,
                    0,
                    Mathf.Sin(angle) * radius
                ); //rotate planet around y axis

                if (angle <= 0)
                {
                    angle = (2 * Mathf.PI); //set angle 2*PI (~6.28) if it reaches 0
                    Debug.Log(transform.tag + " orbit complete"); //print orbit complete message with tag of planet
                }
            }

            yield return new WaitForSeconds(0.01f); //wait for 0.01 seconds before repeating
        }
    }
}
