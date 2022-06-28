using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehv : MonoBehaviour
{
    private float angle = 0; // angle of rotation
    public float angleSpeed = 1; // speed of rotation

    [SerializeField]
    private bool changeRotationDirection = true; // direction of rotation
    IEnumerator rotate; // coroutine for rotation process

    // Start is called before the first frame update
    void Start()
    {
        rotate = SelfRotateBehv();
        StartCoroutine(rotate); // start coroutine
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator SelfRotateBehv()
    {
        while (true)
        {
            if (changeRotationDirection) //Check rotation direction
            {
                angle += angleSpeed * Time.deltaTime; //set rotation speed
                transform.rotation = Quaternion.Euler(0, angle, 0); //rotate planet around y axis

                if (angle >= 360)
                {
                    angle = 0; //reset angle if it reaches 360
                    Debug.Log(transform.tag + " self-rotation complete"); //print self-rotation complete message with tag of planet
                }
            }
            else
            {
                angle -= angleSpeed * Time.deltaTime; //set rotation speed
                transform.rotation = Quaternion.Euler(0, angle, 0); //rotate planet around y axis

                if (angle <= 0)
                {
                    angle = 360; //reset angle if it reaches 0
                    Debug.Log(transform.tag + " self-rotation complete"); //print self-rotation complete message with tag of planet
                }
            }

            yield return new WaitForSeconds(0.01f); //wait for 0.01 seconds before repeating
        }
    }
}
