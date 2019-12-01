﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkStorm : MonoBehaviour
{
    public Vector3 rotSpeed;
    public float followSpeed;
    public GameObject player;

    public float waitTime;
    public float colliderTime;
    bool colliderEnabled;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(rotSpeed * Time.deltaTime);
        
        if (colliderTime != 0 && Time.time > colliderTime)
        {
            colliderTime = 0;
            GetComponent<SphereCollider>().enabled = true;
            Debug.Log("enable collider");
        }

        if (transform.position != player.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, followSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(rotSpeed * Time.deltaTime);
        }
        
    }

    private void onTriggerEnter(GameObject other)
    {
        Debug.Log("detected");
        other.transform.Rotate(-90, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
