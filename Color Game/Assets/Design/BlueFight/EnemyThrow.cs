using System.Collections;
using UnityEngine;


public class EnemyThrow : MonoBehaviour
{
    public float numBalls;
    public float firingAngle;
    public float gravityNum;
    public float waitSec;
    public float rotationAdder;
    public float rotationMultiplier;
    public bool finishedThrowing;

    public GameObject snowball;
    public GameObject theTarget;
    
    bool change = false;
    float snowballsThrown = 0;

    public GameObject snowballClone;
    Transform myTransform;
    Transform Target;
    Transform Projectile;

    public bool moveLeft, moveRight;
    bool makeMoveL, makeMoveR, changeDir = true;
    Vector3 way1, way2, orgPos;
    Vector3 up, down;

    static Vector3 orgPosL, orgPosR;
    bool bouncy = false;
    public bool wasBouncy;

    void Start()
    {
        //way1 = new Vector3(transform.position.x, transform.position.y, transform.position.z + 6f);
        //way2 = new Vector3(transform.position.x, transform.position.y, transform.position.z - 6f);
        orgPos = transform.position;
        up = new Vector3(transform.position.x, transform.position.y+1, transform.position.z);
        
    }

    public void ThrowSnow()
    {
         
        if (snowballsThrown != numBalls)
        {
            snowballClone = Instantiate(snowball, transform.position, transform.rotation);
            //Debug.Log("Ball: " + (snowballsThrown + 1));
            snowballClone.GetComponent<MeshRenderer>().enabled = false;
            myTransform = transform;
            Target = theTarget.transform;
            Projectile = snowballClone.transform;
            
            StartCoroutine(SimulateProjectile());
        }
        else
        {
            finishedThrowing = true;
        }

    }
    

    IEnumerator SimulateProjectile()
    {
        //snowballClone.transform.parent = gameObject.transform;
        snowballsThrown++;
        if (change)
        {
            // Short delay added before Projectile is thrown
            if(rotationMultiplier != 1 || rotationAdder == 0)yield return new WaitForSeconds(waitSec * rotationMultiplier);
            if (rotationAdder != 0) yield return new WaitForSeconds(waitSec + rotationAdder);
            change = false;
        }
        else
        {
            yield return new WaitForSeconds(waitSec);
            change = true;
        }
        

        // Move projectile to the position of throwing object + add some offset if needed.
        Projectile.position = myTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(Projectile.position, Target.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravityNum);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate projectile to face the target.
        Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);

        float elapse_time = 0;
        snowballClone.GetComponent<MeshRenderer>().enabled = true;
        while (elapse_time < flightDuration)
        {
            
            if (Projectile != null)
            {
                Projectile.Translate(0, (Vy - (gravityNum * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);
            }
            elapse_time += Time.deltaTime;
            yield return null;
        }

       

        if(!moveLeft && !moveRight) ThrowSnow();
        if (moveRight)
        {
            makeMoveR = true;
            bouncy = false;
            
        }
        if (moveLeft)
        {
            makeMoveL = true;
            bouncy = false;
        }

    }

    void Update()
    {
        if (bouncy)
        {
            float time = Mathf.PingPong(Time.time * 2, 1);
            transform.position = Vector3.Lerp(orgPos, up, time);
        }
        

        if (makeMoveR)
        {
            if (changeDir)
            {
                //Debug.Log("lllll");
                //Debug.Log(transform.position + "lllll" + orgPosR);
                transform.position = Vector3.Lerp(transform.position, orgPosR, 0.1f);

                if (Vector3.Distance(transform.position, orgPosR) < 0.1f)
                {
                   // Debug.Log("2222");
                    changeDir = false;
                    makeMoveR = false;
                    if (wasBouncy) bouncy = true;
                    ThrowSnow();
                }
            }
            else{
                transform.position = Vector3.Lerp(transform.position, orgPosL, 0.1f);

                if (Vector3.Distance(transform.position, orgPosL) < 0.1f)
                {
                    //Debug.Log("4444");
                    changeDir = true;
                    makeMoveR = false;
                    if (wasBouncy) bouncy = true;
                    ThrowSnow();
                }
            }
        }

        if (makeMoveL)
        {
            if (changeDir)
            {
                //Debug.Log("lllll");
               // Debug.Log(transform.position + "lllll" + way2);
                transform.position = Vector3.Lerp(transform.position, orgPosL, 0.1f);

                if (Vector3.Distance(transform.position, orgPosL) < 0.1f)
                {
                    //Debug.Log("6666");
                    changeDir = false;
                    makeMoveL = false;
                    if (wasBouncy) bouncy = true;
                    ThrowSnow();
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, orgPosR, 0.1f);

                if (Vector3.Distance(transform.position, orgPosR) < 0.1f)
                {
                    //Debug.Log("8888");
                    changeDir = true;
                    makeMoveL = false;
                    if (wasBouncy) bouncy = true;
                    ThrowSnow();
                }
            }
        }
    }

    public void StartThrowing()
    {
        snowballsThrown = 0;
        finishedThrowing = false;
        Collider selfCollider = GetComponent<Collider>();
        selfCollider.enabled = false;
        if(wasBouncy) bouncy = true;
        if (moveRight) orgPosL = transform.position;
        if (moveLeft) orgPosR = transform.position;
        ThrowSnow();
    }
    

    
}