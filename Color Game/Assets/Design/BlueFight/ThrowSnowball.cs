using System.Collections;
using UnityEngine;


public class ThrowSnowball : MonoBehaviour
{

    public static bool go;
    public GameObject theTarget;
    public GameObject snowball;
    public float firingAngle = 45.0f;
    public float gravityNum;
    public float waitSec;
    public float rotationMultiplier;
    public float enemyLevel;
    public GameObject levelTrig;
    bool change = false;
    Transform myTransform;
    GameObject snowballClone;
    Transform Target;
    Transform Projectile;
    

    public void ThrowSnow()
    {
        snowballClone = Instantiate(snowball, transform.position, transform.rotation);
        myTransform = transform;
        Target = theTarget.transform;
        Projectile = snowballClone.transform;
        BlueLevelTrigger.ballsThrown++;
        //Debug.Log("Ball: " + BlueLevelTrigger.ballsThrown);
        StartCoroutine(SimulateProjectile());
    }
    

    IEnumerator SimulateProjectile()
    {
        if (change)
        {
            // Short delay added before Projectile is thrown
            yield return new WaitForSeconds(waitSec * rotationMultiplier);
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

        while (elapse_time < flightDuration)
        {
            if (Projectile == null) break;
            
            Projectile.Translate(0, (Vy - (gravityNum * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;

            yield return null;
            
        }

        if (BlueLevelTrigger.ballsThrown >= 6 && enemyLevel == 1)
        {
            yield return new WaitForSeconds(3f);
            BlueLevelTrigger.moveAlong = true;
        }
        if (BlueLevelTrigger.ballsThrown >= 12 && enemyLevel == 2)
        {
        }
        else
        {
            ThrowSnow();
        }
    }

    void Update()
    {
        if (BlueLevelTrigger.moveAlong && enemyLevel == 1)
        {
            //theTarget.transform.position = Vector3.MoveTowards(theTarget.transform.position, levelTrig.transform.position, 7f * Time.deltaTime);
            theTarget.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }

        if (BlueLevelTrigger.ballsThrown >= 12 && enemyLevel == 2 && GameObject.FindWithTag("Snowball") == null)
        {
            //theTarget.transform.position = Vector3.MoveTowards(theTarget.transform.position, levelTrig.transform.position, 7f * Time.deltaTime);
            theTarget.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == theTarget)
        {
            Collider selfCollider = GetComponent<Collider>();
            selfCollider.enabled = false;
            ThrowSnow();
        }
    }
    

    
}