using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform target;
    public float orbitDegreesPerSec;
    public Vector3 relativeDistance = Vector3.zero;

    // Use this for initialization
    void Start()
    {

        if (target != null)
        {
            relativeDistance = transform.position - target.position;
            Debug.Log("rd: " + relativeDistance);
        }
    }

    void doOrbit()
    {
        if (target != null)
        {
            transform.position = target.position + relativeDistance;
            transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);
            relativeDistance = transform.position - target.position;
        }
    }

    void LateUpdate()
    {

        doOrbit();

    }
}
