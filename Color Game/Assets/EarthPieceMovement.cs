using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPieceMovement : MonoBehaviour
{
    public GameObject player;
    Vector3 risePos, destPos;
    bool rise, goTowards;
    public float travelLen = 3f;
    private float stopit;
    // Start is called before the first frame update
    void Start()
    {
        rise = true;
        risePos = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);
        destPos = transform.TransformPoint(new Vector3(0, 0, 20));
        destPos = new Vector3(destPos.x, destPos.y + 3, destPos.z);
        Debug.Log("dp: " + destPos);
        stopit = Time.time + travelLen;
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
            //transform.position = Vector3.MoveTowards(transform.position, destPos, 60f * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * 20f;
            
            if (Time.time >= stopit)
            {
               Destroy(gameObject);
            }
        }
        else
        {
            goTowards = false;
            //Debug.Log("hit");
        }
    }

    void onCollisionEnter(Collision other)
    {
        // Destroy
    }

    void OnTriggerEnter(Collider other)
    {
        //other.gameObject.transform.parent = transform;
    }

    void continueAttack()
    {
        goTowards = true;
    }
}
