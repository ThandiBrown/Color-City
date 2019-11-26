using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("fortiesn");
        if (other.gameObject.transform.name == "LeftEnemy(Clone)" || other.gameObject.transform.name == "RightEnemy(Clone)") Destroy(transform.parent.gameObject);
    }
}
