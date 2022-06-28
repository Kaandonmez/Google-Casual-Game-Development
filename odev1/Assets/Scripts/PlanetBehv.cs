using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehv : MonoBehaviour
{
    //rotate object around y-axis, after 1 full rotation, print "rotation comlete"

    public float angle = 0;
    public float angleSpeed = 1;

    IEnumerator rotate;

    //serializedfield checkbox
    [SerializeField]
    private bool changeRotationDirection = true;

    // Start is called before the first frame update
    void Start()
    {
        rotate = RotateBehv();
        StartCoroutine(rotate);
    }

    // Update is called once per frame
    void Update() { }

    IEnumerator RotateBehv()
    {
        while (true)
        {
            if (changeRotationDirection)
            {
                angle += angleSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, angle, 0);

                if (angle >= 360)
                {
                    angle = 0;
                    Debug.Log(transform.tag + " self-rotation complete");
                }
            }
            else
            {
                angle -= angleSpeed * Time.deltaTime;
                transform.rotation = Quaternion.Euler(0, angle, 0);

                if (angle <= 0)
                {
                    angle = 360;
                    Debug.Log(transform.tag + " self-rotation complete");
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
