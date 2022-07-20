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
    public float yPos = 50f; //y position of the camera

    public float radius = 120f; // camera rotation radius

    private float angle = 0; // angle of rotation (camera)
    public float angleSpeed = 0.08f; // speed of rotation (camera)

    public GameObject meteor; // meteor prefab

    //store staring positon of object
    Vector3 Pos;

    [SerializeField]
    public int initialMeteorSpeed = 150;

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
                //if left mouse button is pressed instantiate meteor
                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 pos = new Vector3(
                        Random.Range(-MeteorSpwnRange, MeteorSpwnRange),
                        0,
                        Random.Range(-MeteorSpwnRange, MeteorSpwnRange)
                    );
                    GameObject meteorInstance = Instantiate(meteor, pos, Quaternion.identity);

                    //after instantiate meteor apply force to meteor through x axis
                    meteorInstance
                        .GetComponent<Rigidbody>()
                        .AddForce(meteorInstance.transform.forward * initialMeteorSpeed);

                    //after instantiate meteor apply force to meteor through z axis
                    meteorInstance
                        .GetComponent<Rigidbody>()
                        .AddForce(meteorInstance.transform.right * initialMeteorSpeed);

                    Debug.Log(
                        "Meteor instantiated at "
                            + pos
                            + " with"
                            + initialMeteorSpeed.ToString()
                            + " force"
                    );
                }
                //Debug.Log("Mouse moved");
                yield return new WaitForSeconds(2f);
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
