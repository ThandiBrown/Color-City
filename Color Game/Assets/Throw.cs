using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;

    private Vector3 moveDirection;
    
    public static bool once = true;
    public static bool firstClick = false;
    public static bool regularMovement = true;
    private float endpoint;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
        }

        if (regularMovement)
        {
            moveDirection = new Vector3(1 * moveSpeed, moveDirection.y, 6);
            if (once) {
                moveDirection.y = -1;
                moveDirection.y = jumpForce;
                moveSpeed = 10;
                firstClick = true;
                once = false;
            }
            
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            controller.Move(moveDirection * Time.deltaTime);

            if (controller.isGrounded && firstClick)
            {
                regularMovement = false;
            }

        }
    }
}
