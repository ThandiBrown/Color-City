using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toward : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;
    Vector3 shoot;
    private Vector3 moveDirection;

    public GameObject goal;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        shoot = (goal.transform.position - transform.position).normalized;

    }

    // Update is called once per frame
    void Update()
    {
            moveDirection = shoot;
            moveDirection.y = -1;
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            controller.Move(moveDirection * Time.deltaTime);
        

        
    }
}
