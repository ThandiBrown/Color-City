using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject snowball;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(snowball, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
