using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class side : MonoBehaviour
{
    public float speed;
    public float unitAcross = 5;
    Vector3 pointA;
    Vector3 pointB;

    void Start()
    {
        speed =10f * Time.deltaTime;
        pointA = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        pointB = new Vector3(transform.position.x + unitAcross, transform.position.y, transform.position.z);
    }

    void Update()
    {
        //float time = Mathf.PingPong(Time.time * speed, 1);
        //transform.position = Vector3.Lerp(pointA, pointB, time);
    }

    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.transform.parent = null;

    }
}
