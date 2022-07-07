using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectMouseClick : MonoBehaviour
{
    [SerializeField]
    public GameObject panel;

    [SerializeField]
    public GameObject panelText;

    [SerializeField]
    public TMP_Text panelTextPro;

    public bool isClickedOnPlanet = false;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //check if mouse is clicked on the planet
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Planet" || hit.transform.tag == "Sun")
                {
                    //change panelTextPro to planet name
                    panelTextPro.text = hit.transform.name;

                    //change panelText to planet rigidbody mass value
                    panelText.GetComponent<Text>().text =
                        "Planet Mass: " + hit.transform.GetComponent<Rigidbody>().mass.ToString();

                    isClickedOnPlanet = true;
                    panel.SetActive(true);

                    //change panel text to gameobject name


                    Debug.Log("You clicked on " + hit.transform.tag);
                }

                if (!panel.activeSelf)
                {
                    isClickedOnPlanet = false;
                }
            }
        }
    }
}
