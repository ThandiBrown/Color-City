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
    bool sleepFieldOn = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {

            p1Clone = Instantiate(p1, transform.position, Quaternion.Euler(-90, 0, 0));
            p1Clone.GetComponent<SleepBurst>().player = transform.gameObject;
            p1Clone.Play();
        }

       moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
       controller.Move(moveDirection * Time.deltaTime);
        
    }
}
