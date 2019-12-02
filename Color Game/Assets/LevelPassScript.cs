using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPassScript : MonoBehaviour
{
    public static bool entered;
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
        Debug.Log("cool");
        entered = true;
    }
}
