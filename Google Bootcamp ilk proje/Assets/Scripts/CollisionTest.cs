using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start");
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
}
