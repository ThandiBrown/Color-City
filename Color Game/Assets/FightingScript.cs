using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingScript : MonoBehaviour
{
    public GameObject snowball;
    GameObject snowballClone;
    float fire_start_time;
    public Transform camerar;
    // Start is called before the first frame update
    void Start()
    {
        fire_start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && (Time.time - fire_start_time) >= 0.15f)
        {
            Debug.Log("Trouble55");
            fire_start_time = Time.time;
            snowballClone = Instantiate(snowball, transform.position, camerar.rotation);
            //snowballClone.GetComponent<PlayerSnowball>().playerTransform = transform;
        }
        
    }
}
