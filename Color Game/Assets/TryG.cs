using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryG : MonoBehaviour
{
    public float moveSpeed;
    public float gravityScale;
    public float jumpForce;
    public CharacterController controller;
    Vector3 moveDirection;
    public ParticleSystem p1;
    ParticleSystem p1Clone;


    bool wasMoving = false, setUp = true;
    float setupTime;
    float setupDone;
    // Start is called before the first frame update
    void Start()
    {
        setupTime = 4.5f;
        setupDone = Time.time + setupTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            p1Clone = Instantiate(p1, transform.position, Quaternion.Euler(-90, 0, 0));
            p1Clone.GetComponent<PinkStorm>().player = transform.gameObject;
            p1Clone.Play();
            
        }

        if (Time.time > setupDone && p1Clone != null && setUp)
        {
            p1Clone.GetComponent<SphereCollider>().enabled = true;
            Debug.Log("enabled setup collider");
            setUp = false;
        }

        /*
        if (wasMoving)
        {
            if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            {
                wasMoving = false;
                p1Clone.GetComponent<PinkStorm>().colliderTime = Time.time + p1Clone.GetComponent<PinkStorm>().waitTime;
                Debug.Log("time set");
            }
        }
        
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            setUp = false;
            if(!wasMoving) Debug.Log("movement detected");
            p1Clone.GetComponent<PinkStorm>().colliderTime = 0;
            p1Clone.GetComponent<SphereCollider>().enabled = false;
            wasMoving = true;
            
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        controller.Move(moveDirection * Time.deltaTime);
        */
    }
}
