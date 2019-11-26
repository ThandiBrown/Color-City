using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class find : MonoBehaviour
{
    public GameObject ball;
    bool goTowards = false, rise = false;
    Vector3 riseLocation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rise)
        {
            transform.position = Vector3.MoveTowards(transform.position, riseLocation, 5f * Time.deltaTime);
        }
        else if (goTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, ball.transform.position, 5f * Time.deltaTime);
        }

        

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name != "Terrain")
                {
                    Debug.Log(hit.transform.gameObject.name);
                    ball = hit.transform.gameObject;
                    rise = true;
                    goTowards = true;
                    //if (hit.transform.name == "Snowball(Clone)") Destroy(hit.transform.gameObject);
                }

            }

        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == ball)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            goTowards = false;
        }
    }
}
