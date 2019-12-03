using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthWeapon : MonoBehaviour
{
    public GameObject otherEarth;

    public GameObject ball;
    public GameObject player;
    Vector3 risePos;
    static bool goTowards;
    bool rise, face;
    public static float count = 0;
    public static float speed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        count++;
        rise = true;
        risePos = new Vector3(player.transform.position.x, transform.position.y + 3, player.transform.position.z + 3);
        face = false;
        goTowards = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (rise && ball != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, risePos, 10f * Time.deltaTime);

            if (transform.position.y >= risePos.y)
            {
                rise = false;
                Invoke("continueAttack", 0.1f);
            }
        }
        else if (ball == null)
        {
            rise = false;
            Destroy(gameObject);
        }

        if (face && ball != null)
        {
            if (goTowards) Debug.Log("oof");
            transform.LookAt(ball.transform, Vector3.up);

            Vector3 dirFromAtoB = (ball.transform.position - transform.position).normalized;
            float dotProd = Vector3.Dot(dirFromAtoB, transform.forward);

            if (dotProd > 0.9)
            {
                Debug.Log("closer");
                face = false;
                goTowards = true;
            }
        }
        else if (ball == null)
        {
            face = false;
            Destroy(gameObject);
        }

        if (goTowards && ball != null)
        {
            if (gameObject != null && ball != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, ball.transform.position, speed * Time.deltaTime);
            }
            else
            {
                goTowards = false;
                Debug.Log("hit");
            }

        }
        else if (ball == null)
        {
            goTowards = false;
            Destroy(gameObject);
        }
    }

    void continueAttack()
    {
        Debug.Log("mimp");
        face = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GreenEnemy>().hydra == true)
        {
            Debug.Log("jjjjjjjjjjjjj");
            other.gameObject.GetComponent<GreenEnemy>().FormHydra();
        }
        else
        {
            Debug.Log("eeeeeeeee");
            Destroy(other.gameObject);
            if (other.gameObject != otherEarth || gameObject.name == "EarthWeapon(Clone)")
            {
                
                Destroy(gameObject);
            }
        }

        
        
    }
}
