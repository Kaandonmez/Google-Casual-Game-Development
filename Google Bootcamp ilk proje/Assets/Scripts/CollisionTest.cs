using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");
        Debug.Log("CollisionTest script started");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player entered the trigger");
            //destroy the game object
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay(Collider other) { }
}
