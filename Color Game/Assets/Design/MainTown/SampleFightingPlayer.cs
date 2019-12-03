using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleFightingPlayer : MonoBehaviour
{
    public float moveSpeed;
    public float gravityScale;
    public float jumpForce;
    public CharacterController controller;
    Vector3 moveDirection;
    public ParticleSystem p1;
    ParticleSystem p1Clone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
     //  moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
     //  controller.Move(moveDirection * Time.deltaTime);
        
    }
}
