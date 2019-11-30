using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingScript : MonoBehaviour
{
    public GameObject snowball;
    GameObject snowballClone;
    float fire_start_time;
    public Transform camerar;

    public float moveSpeed;
    private Vector3 moveDirection;
    public CharacterController controller;
    public float jumpForce;
    public float gravityScale;

    
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
            Debug.Log("Trouble55");
            fire_start_time = Time.time;
            snowballClone = Instantiate(snowball, transform.position, camerar.rotation);
            //snowballClone.GetComponent<PlayerSnowball>().playerTransform = transform;
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, 0f);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
