using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public static Vector3 crosshairPos;
    public float moveSpeed;
    private Vector3 moveDirection;
    public CharacterController controller;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * 10f * moveSpeed, Input.GetAxis("Vertical") * 10f * moveSpeed, 0f);
        controller.Move(moveDirection * Time.deltaTime);
        crosshairPos = transform.position;
    }
}
