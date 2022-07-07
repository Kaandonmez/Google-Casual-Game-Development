using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehv : MonoBehaviour
{
    [SerializeField]
    ParticleSystem crashParticle;

    public GameObject meteor;

    void Start() { }

    void update() { }

    //when colliding with another object, destroy the meteor
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Meteor hit something");
        CrashParticle();
        //remove this object from Attractors array in Attractor.cs
        GetComponent<Attractor>()
            .onDisable();
        GetComponent<Attractor>().enabled = false;

        //this.enabled = false;
        Destroy(gameObject, 0.7f);
    }

    void CrashParticle()
    {
        crashParticle.Play();
        Debug.Log("Crash particle played for meteor" + meteor.name);
    }
}
