using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSnowball : MonoBehaviour
{
    public Transform startTransform;
    public float firingAngle = 45.0f;
    public float gravityNum;
    Vector3 landing;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(-2.5f, transform.eulerAngles.y, transform.eulerAngles.z);
        float y = transform.position.y-2;
        Debug.Log("T" + transform.position);
        landing = transform.TransformPoint(new Vector3(0, 0, 10));
        landing.y = y; 
        Debug.Log("L" + landing);
        startTransform = transform;
        StartCoroutine(Travel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Travel()
    {
        
        // Move transform to the position of throwing object + add some offset if needed.
        //transform.position = playerTransform.position + new Vector3(0, 0.0f, 0);

        // Calculate distance to target
        float target_Distance = Vector3.Distance(transform.position, landing);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float transform_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravityNum);

        // Extract the X  Y componenent of the velocity
        float Vx = Mathf.Sqrt(transform_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        float Vy = Mathf.Sqrt(transform_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        // Calculate flight time.
        float flightDuration = target_Distance / Vx;

        // Rotate transform to face the target.
        transform.rotation = Quaternion.LookRotation(landing - transform.position);

        float elapse_time = 0;

        while (elapse_time < flightDuration)
        {
            if (transform == null) break;

            transform.Translate(0, (Vy - (gravityNum * elapse_time)) * Time.deltaTime, Vx * Time.deltaTime);

            elapse_time += Time.deltaTime;
            if (transform.position.y <= 0) Destroy(gameObject);
            yield return null;

        }

        Debug.Log("finished");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("ggggg");
    }
}
