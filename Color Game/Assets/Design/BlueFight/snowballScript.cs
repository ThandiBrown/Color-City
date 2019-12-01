using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    public GameObject otherSnowball;
    public static float totalSnowballsDestroyed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 300.0f))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "Snowball(Clone)")
            {
                Destroy(hit.transform.gameObject);
                totalSnowballsDestroyed++;
                Debug.Log("it is a ray : " + totalSnowballsDestroyed);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != otherSnowball && gameObject != null)
        {
           Destroy(gameObject);
            totalSnowballsDestroyed++;
            //Debug.Log("it is a hit : " + other.gameObject.name + " " + totalSnowballsDestroyed);
        }
    }
}
