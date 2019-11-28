using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingScript : MonoBehaviour
{
    public GameObject snowball;
    float fire_start_time;
    // Start is called before the first frame update
    void Start()
    {
        fire_start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q) && (Time.time - fire_start_time) >= 0.15f)
        {
            fire_start_time = Time.time;
            Instantiate(snowball, transform.position, transform.rotation);
        }
        
    }
}
