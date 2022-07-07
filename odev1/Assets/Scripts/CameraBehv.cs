using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//add unity ui element library
using UnityEngine.UI;

public class CameraBehv : MonoBehaviour
{
    [SerializeField]
    public GameObject panel;

    [SerializeField]
    public float MeteorSpwnRange = 50f;

    [SerializeField]
    public float yPos = 50f;

    public float radius = 120f; // radius of rotation

    private float angle = 0; // angle of rotation
    public float angleSpeed = 0.08f; // speed of rotation

    public GameObject meteor; // meteor prefab

    public bool test = false; // test variable

    //store staring positon of object
    Vector3 Pos;

    private int initialMeteorSpeed = 100;

    // Start is called before the first frame update
    void Start()
    {
        //start coroutine OrbitCamera
        StartCoroutine(OrbitCamera()); // start coroutine
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator OrbitCamera()
    {
        while (true)
        {
            //mousemoveevent
            if (
                Input.GetAxis("Mouse X") != 0
                || Input.GetAxis("Mouse Y") != 0
                || Input.GetMouseButton(0) && !panel.activeSelf
            )
            {
                //if panel.activeSelf is true wait until it is false
                while (panel.activeSelf)
                {
                    yield return null;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 pos = new Vector3(
                        Random.Range(-MeteorSpwnRange, MeteorSpwnRange),
                        0,
                        Random.Range(-MeteorSpwnRange, MeteorSpwnRange)
                    );
                    GameObject meteorInstance = Instantiate(meteor, pos, Quaternion.identity);

                    meteorInstance
                        .GetComponent<Rigidbody>()
                        .AddForce(meteorInstance.transform.forward * initialMeteorSpeed);
                    //Destroy(meteorInstance, 2);

                    Debug.Log(
                        "Meteor instantiated at "
                            + pos
                            + " with"
                            + initialMeteorSpeed.ToString()
                            + " force"
                    );
                }
                //Debug.Log("Mouse moved");
                yield return new WaitForSeconds(0.5f);
            }
            else
            {
                angle += angleSpeed * Time.deltaTime; //set rotation speed
                transform.position = new Vector3(
                    Mathf.Cos(angle) * radius,
                    yPos,
                    Mathf.Sin(angle) * radius
                ); //rotate planet around y axis
                //rotate camera to look at (0,0,0)
                transform.LookAt(Vector3.zero);

                //if angle reaches 2*PI (~6.28) reset angle
                if (angle >= (2 * Mathf.PI))
                {
                    angle = 0;
                }
                yield return null;
            }
        }
    }
}
