﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingScript : MonoBehaviour
{

    public Transform camerar;
    public CharacterController controller;

    public GameObject snowball;
    public GameObject stick;
    public GameObject earthPiece;

    GameObject snowballClone;
    GameObject stickClone;
    GameObject earthPieceClone;

    public float moveSpeed;
    public float gravityScale;
    public float jumpForce;
    
    Vector3 moveDirection;
    bool start = true;
    float fire_start_time;



    // Start is called before the first frame update
    void Start()
    {
        fire_start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C) && (Time.time - fire_start_time) >= 0.10f)
        {
            fire_start_time = Time.time;
            snowballClone = Instantiate(snowball, transform.position, camerar.rotation);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (start)
            {
                start = false;
                stickClone = Instantiate(stick, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 103.45f));
                //Debug.Log("r1:" + stickClone.transform.position);
                stickClone.GetComponent<Orbit>().target = transform;
            }

        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            Destroy(stickClone);
            start = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int i = -2; i < 3; i++)
            {
                earthPieceClone = Instantiate(earthPiece, new Vector3(transform.position.x + i * 2, transform.position.y - 3, transform.position.z + 2), transform.rotation);
                earthPieceClone.GetComponent<EarthPieceMovement>().player = transform.gameObject;
            }

        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, 0f);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
