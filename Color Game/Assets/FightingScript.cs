using System.Collections;
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
    Transform cameraRep;

    public ParticleSystem p1;
    ParticleSystem p1Clone;


    bool wasMoving = false, setUp = true;
    float setupTime;
    float setupDone;
    bool sleepFieldOn = false;

    // Start is called before the first frame update
    void Start()
    {
        fire_start_time = Time.time;
        setupTime = 4.5f;
        setupDone = Time.time + setupTime;
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            cameraRep = Camera.main.transform;
            earthPieceClone = Instantiate(earthPiece, transform.position + cameraRep.forward * 2.5f, Quaternion.Euler(0f, cameraRep.transform.eulerAngles.y, 0f));
            earthPieceClone.transform.position = new Vector3(earthPieceClone.transform.position.x, 0.235f - 2.7f, earthPieceClone.transform.position.z);
            Debug.Log("sp: " + earthPieceClone.transform.position);

            /*
            cameraRep = Camera.main.transform;
            cameraRep.transform.eulerAngles = new Vector3(-2.5f, cameraRep.transform.eulerAngles.y, cameraRep.transform.eulerAngles.z);
            earthPieceClone = Instantiate(earthPiece, transform.position + cameraRep.forward * 2.5f, Quaternion.Euler(0f, cameraRep.transform.eulerAngles.y, 0f));
            earthPieceClone.transform.position = new Vector3(earthPieceClone.transform.position.x, 0.235f - 2.7f, earthPieceClone.transform.position.z);
            Debug.Log("sp: " + earthPieceClone.transform.position);
            /*
            for (int i = -2; i < 3; i++)
            {
                earthPieceClone = Instantiate(earthPiece, new Vector3(transform.position.x + i * 2, transform.position.y - 3, transform.position.z + 2), transform.rotation);
                earthPieceClone.GetComponent<EarthPieceMovement>().player = transform.gameObject;
            }
            */
        }

        if (Input.GetKeyDown(KeyCode.M))
        {

            p1Clone = Instantiate(p1, transform.position, Quaternion.Euler(-90, 0, 0));
            p1Clone.GetComponent<PinkStorm>().player = transform.gameObject;
            p1Clone.Play();
            sleepFieldOn = true;
        }
        if (sleepFieldOn)
        {
            if (Time.time > setupDone && p1Clone != null && setUp)
            {
                p1Clone.GetComponent<SphereCollider>().enabled = true;
                Debug.Log("enabled setup collider");
                setUp = false;
            }


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
                if (!wasMoving) Debug.Log("movement detected");
                p1Clone.GetComponent<PinkStorm>().colliderTime = 0;
                p1Clone.GetComponent<SphereCollider>().enabled = false;

                wasMoving = true;

            }
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
