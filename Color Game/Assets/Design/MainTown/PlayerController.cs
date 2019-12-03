using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public float gravityScale;
    public CharacterController controller;

    private Vector3 moveDirection;
    public Transform pivot;
    public float rotateSpeed;
    public GameObject playerModel;

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
    float timeToSetUpStorm;
    float timeSetupStormDone;
    bool stormFieldOn = false;


    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSnowballs = Time.time;
        timeToSetUpStorm = 4.5f;
        timeSetupStormDone = Time.time + timeToSetUpStorm;
        spinStick = true;
    }

    void InstantiateSnowball()
    {
        timeBetweenSnowballs = Time.time;
        snowballClone = Instantiate(snowball, transform.position, Camera.main.transform.rotation);
    }

    void ActivateStick()
    {
        if (spinStick)
        {
            spinStick = false;
            stickClone = Instantiate(stick, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 103.45f));
            stickClone.GetComponent<Orbit>().target = transform;
        }
    }

    void DeactivateStick()
    {
        Destroy(stickClone);
        spinStick = true;
    }

    void LaunchEarthPiece()
    {
        cameraRep = Camera.main.transform;
        earthPieceClone = Instantiate(earthPiece, transform.position + cameraRep.forward * 2.5f, Quaternion.Euler(0f, cameraRep.transform.eulerAngles.y, 0f));
        earthPieceClone.transform.position = new Vector3(earthPieceClone.transform.position.x, 0.235f - 2.7f, earthPieceClone.transform.position.z);
    }

    void SleepBurst()
    {
        speedBurstClone = Instantiate(speedBurst, transform.position, Quaternion.Euler(-90, 0, 0));
        speedBurstClone.GetComponent<SleepBurst>().player = transform.gameObject;
        speedBurstClone.Play();
    }

    void SleepStorm()
    {
        sleepStormClone = Instantiate(sleepStorm, transform.position, Quaternion.Euler(-90, 0, 0));
        sleepStormClone.GetComponent<PinkStorm>().player = transform.gameObject;
        sleepStormClone.Play();
        stormFieldOn = true;
    }

    // Update is called once per frame
    void Update()
    {

     //---------------------- Powers ----------------------------------------------------
        if (Input.GetKey(KeyCode.F) && (Time.time - timeBetweenSnowballs) >= 0.10f) InstantiateSnowball();

        if (Input.GetKeyDown(KeyCode.T)) ActivateStick();

        if (Input.GetKeyUp(KeyCode.T)) DeactivateStick();

        if (Input.GetKeyDown(KeyCode.E)) LaunchEarthPiece();

        if (Input.GetKeyDown(KeyCode.C)) SleepBurst();

        if (Input.GetKeyDown(KeyCode.G)) SleepStorm();

        if (stormFieldOn)
        {
            // Storm Collider
            if (Time.time > timeSetupStormDone && sleepStormClone != null && setUpShield)
            {
                sleepStormClone.GetComponent<SphereCollider>().enabled = true;
                setUpShield = false;
            }
            // Disable Storm Collider with Movement
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                setUpShield = false;
                //if (!movingWithShield) Debug.Log("movement detected");
                sleepStormClone.GetComponent<PinkStorm>().colliderTime = 0;
                sleepStormClone.GetComponent<SphereCollider>().enabled = false;
                movingWithShield = true;

            }
            // Enabled Storm Collider when Still
            if (movingWithShield)
            {
                if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
                {
                    movingWithShield = false;
                    sleepStormClone.GetComponent<PinkStorm>().colliderTime = Time.time + sleepStormClone.GetComponent<PinkStorm>().waitTime;
                }
            }

            
        }

     //--------------------------------------- Movement --------------------------------------------------

        float yStore = moveDirection.y;
        
        moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
        
        moveDirection = moveDirection.normalized * moveSpeed;
        moveDirection.y = yStore;
        if (controller.isGrounded)
        {
            moveDirection.y = -1f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        }

        controller.Move(moveDirection * Time.deltaTime);
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        }
    }
    
}
