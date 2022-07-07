using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attractor : MonoBehaviour
{
    const float G = 66.74f;
    public Rigidbody rb;

    public static List<Attractor> Attractors = new List<Attractor>();

    void FixedUpdate()
    {
        foreach (Attractor attractor in Attractors)
        {
            if (attractor != this)
            {
                Attract(attractor);
            }
        }
    }

    void OnEnable()
    {
        if (Attractors == null)
        {
            Attractors = new List<Attractor>();
        }
        Attractors.Add(this);
    }

    public void onDisable()
    {
        Attractors.Remove(this);
    }

    void Attract(Attractor objToAttract)
    {
        if (GetComponent<MeteorBehv>() != null)
        {
            if (GetComponent<MeteorBehv>().enabled == false)
            {
                onDisable();
            }
        }

        try
        {
            Rigidbody rbToAttract = objToAttract.rb;

            Vector3 direction = rb.position - rbToAttract.position;
            float distance = direction.magnitude;
            if (distance == 0f)
            {
                return;
            }

            float forceMagnitude = G * (rb.mass * rbToAttract.mass) / (distance * distance);
            Vector3 force = direction.normalized * forceMagnitude;

            rbToAttract.AddForce(force);
        }
        catch (System.Exception)
        {
            throw;
        }
    }
}
