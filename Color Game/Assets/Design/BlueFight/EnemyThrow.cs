using System.Collections;
using UnityEngine;


public class EnemyThrow : MonoBehaviour
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
    float snowballsThrown = 0;
    public void ThrowSnow()
    {
        if (snowballsThrown != 3)
        {
            snowballClone = Instantiate(snowball, transform.position, transform.rotation);
            myTransform = transform;
            Target = theTarget.transform;
            Projectile = snowballClone.transform;
            Debug.Log("Ball: " + (snowballsThrown+1));
            StartCoroutine(SimulateProjectile());
        }
        else
        {

        }
        
    }
    

    IEnumerator SimulateProjectile()
    {
        snowballsThrown++;
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
        ThrowSnow();
    }
    

    public void StartThrowing()
    {
        snowballsThrown = 0;
        Collider selfCollider = GetComponent<Collider>();
        selfCollider.enabled = false;
        ThrowSnow();
    }
    

    
}