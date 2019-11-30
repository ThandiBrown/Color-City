using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPieceMovement : MonoBehaviour
{
    public GameObject player;
    Vector3 risePos, destPos;
    bool rise, goTowards;
    // Start is called before the first frame update
    void Start()
    {
        rise = true;
        risePos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        destPos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z + 20);
    }

    // Update is called once per frame
    void Update()
    {
        if (rise)
        {
            transform.position = Vector3.MoveTowards(transform.position, risePos, 3f * Time.deltaTime);

            if (transform.position.y >= risePos.y)
            {
                rise = false;
                Invoke("continueAttack", 0.2f);
                
                //Invoke("continueAttack", 0.1f);
            }
        }

        if (gameObject != null && goTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, destPos, 25f * Time.deltaTime);

            if (transform.position.z >= destPos.z)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            goTowards = false;
            Debug.Log("hit");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }

    void continueAttack()
    {
        goTowards = true;
    }
}
