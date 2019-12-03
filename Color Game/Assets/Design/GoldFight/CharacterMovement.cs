using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public static bool movementIsHappening = false;
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            movementIsHappening = false;
        }
        if (!SpearAttack.jabIsHappening && !SpearAttack.swingIsHappening)
        {
            movementIsHappening = true;
            moveDirection = new Vector3(0f, 0f, -Input.GetAxis("Horizontal") * moveSpeed);
            controller.Move(moveDirection * Time.deltaTime);
        }
        
        
    }
}
