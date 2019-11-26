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
        if (rise)
        {
            transform.position = Vector3.MoveTowards(transform.position, risePos, 10f * Time.deltaTime);

            if (transform.position.y >= risePos.y)
            {
                rise = false;
                Invoke("continueAttack", 0.1f);
            }
        }

        if (face)
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

        if (goTowards)
        {
            if (gameObject != null && ball != null)
            {
                transform.position = Vector3.MoveTowards(transform.position, ball.transform.position, 25f * Time.deltaTime);
            }
            else
            {
                goTowards = false;
                Debug.Log("hit");
            }

        }
    }

    void continueAttack()
    {
        Debug.Log("mimp");
        face = true;
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (other.gameObject != otherEarth || gameObject.name == "EarthWeapon(Clone)")
        {
            Destroy(gameObject);
        }
        
    }
}
