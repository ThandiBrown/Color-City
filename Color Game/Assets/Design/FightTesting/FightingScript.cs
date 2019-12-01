using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingScript : MonoBehaviour
{
    public CharacterController controller;
    public float moveSpeed;
    public float gravityScale;
    public float jumpForce;
    Vector3 moveDirection;

    public GameObject snowball;
    public GameObject stick;
    public GameObject earthPiece;
    public ParticleSystem sleepStorm;
    public ParticleSystem speedBurst;
    
    GameObject snowballClone;
    GameObject stickClone;
    GameObject earthPieceClone;
    ParticleSystem sleepStormClone;
    ParticleSystem speedBurstClone;
    
    bool spinStick;
    float timeBetweenSnowballs;
    Transform cameraRep;
    
    bool movingWithShield = false, setUpShield = true;
    float setupShieldTime;
    float setupShieldDone;
    bool sleepFieldOn = false;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSnowballs = Time.time;
        setupShieldTime = 4.5f;
        setupShieldDone = Time.time + setupShieldTime;
        spinStick = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C) && (Time.time - timeBetweenSnowballs) >= 0.10f)
        {
            timeBetweenSnowballs = Time.time;
            snowballClone = Instantiate(snowball, transform.position, Camera.main.transform.rotation);
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (spinStick)
            {
                spinStick = false;
                stickClone = Instantiate(stick, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 103.45f));
                stickClone.GetComponent<Orbit>().target = transform;
            }

        }

        if (Input.GetKeyUp(KeyCode.T))
        {
            Destroy(stickClone);
            spinStick = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            cameraRep = Camera.main.transform;
            earthPieceClone = Instantiate(earthPiece, transform.position + cameraRep.forward * 2.5f, Quaternion.Euler(0f, cameraRep.transform.eulerAngles.y, 0f));
            earthPieceClone.transform.position = new Vector3(earthPieceClone.transform.position.x, 0.235f - 2.7f, earthPieceClone.transform.position.z);
            //Debug.Log("sp: " + earthPieceClone.transform.position);
            
        }

        if (Input.GetKeyDown(KeyCode.M))
        {

            speedBurstClone = Instantiate(speedBurst, transform.position, Quaternion.Euler(-90, 0, 0));
            speedBurstClone.GetComponent<SleepBurst>().player = transform.gameObject;
            speedBurstClone.Play();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {

            sleepStormClone = Instantiate(sleepStorm, transform.position, Quaternion.Euler(-90, 0, 0));
            sleepStormClone.GetComponent<PinkStorm>().player = transform.gameObject;
            sleepStormClone.Play();
            sleepFieldOn = true;
        }
        if (sleepFieldOn)
        {
            if (Time.time > setupShieldDone && sleepStormClone != null && setUpShield)
            {
                sleepStormClone.GetComponent<SphereCollider>().enabled = true;
                //Debug.Log("enabled setup collider");
                setUpShield = false;
            }


            if (movingWithShield)
            {
                if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
                {
                    movingWithShield = false;
                    sleepStormClone.GetComponent<PinkStorm>().colliderTime = Time.time + sleepStormClone.GetComponent<PinkStorm>().waitTime;
                    //Debug.Log("time set");
                }
            }

            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                setUpShield = false;
                //if (!movingWithShield) Debug.Log("movement detected");
                sleepStormClone.GetComponent<PinkStorm>().colliderTime = 0;
                sleepStormClone.GetComponent<SphereCollider>().enabled = false;

                movingWithShield = true;

            }
        }

        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        controller.Move(moveDirection * Time.deltaTime);
    }


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
