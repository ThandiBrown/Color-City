using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense : MonoBehaviour
{
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward*500);
    }

}
