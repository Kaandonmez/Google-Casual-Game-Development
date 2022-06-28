using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotBehv : MonoBehaviour
{
    public float radius = 4f;

    public float angle = 0;
    public float angleSpeed = 1;

    [SerializeField]
    private bool changeOrbitDirection = true;

    IEnumerator orbit;

    //store staring posiiton of object
    Vector3 Pos;

    // Start is called before the first frame update
    void Start()
    {
        orbit = OrbitBehv();
        StartCoroutine(orbit);
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator OrbitBehv()
    {
        //radius equals to distance between object and (0,0,0)
        radius = Vector3.Distance(transform.position, Vector3.zero);

        while (true)
        {
            if (changeOrbitDirection)
            {
                angle += angleSpeed * Time.deltaTime;
                transform.position = new Vector3(
                    Mathf.Cos(angle) * radius,
                    0,
                    Mathf.Sin(angle) * radius
                );

                if (angle >= (2 * Mathf.PI))
                {
                    angle = 0;
                    Debug.Log(transform.tag + " orbit complete");
                }
            }
            else
            {
                angle -= angleSpeed * Time.deltaTime;
                transform.position = new Vector3(
                    Mathf.Cos(angle) * radius,
                    0,
                    Mathf.Sin(angle) * radius
                );

                if (angle <= 0)
                {
                    angle = (2 * Mathf.PI);
                    Debug.Log(transform.tag + " orbit complete");
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
