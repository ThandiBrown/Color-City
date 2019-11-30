using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeplayer : MonoBehaviour
{
    bool start = true;
    public GameObject stick;
    GameObject stickClone;
    public float moveSpeed;
    private Vector3 moveDirection;
    public CharacterController controller;
    public float jumpForce;
    public float gravityScale;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (start)
            {
                start = false;
                stickClone = Instantiate(stick, new Vector3(transform.position.x+2, transform.position.y, transform.position.z), Quaternion.Euler(0,0,103.45f));
                //Debug.Log("r1:" + stickClone.transform.position);
                stickClone.GetComponent<Orbit>().target = transform;
            }
            
        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            Destroy(stickClone);
            start = true;
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        controller.Move(moveDirection * Time.deltaTime);
        
    }
}
