using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballScript : MonoBehaviour
{
    public GameObject otherSnowball;
    public static float totalSnowballsDestroyed = 0;
    public ParticleSystem endSparks;
    ParticleSystem endSparksClone;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 300.0f))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.name == "Snowball(Clone)")
            {
                endSparksClone = Instantiate(endSparks, transform.position, Quaternion.Euler(-90, 0, 0));
                endSparksClone.Play();
                Destroy(hit.transform.gameObject);
                totalSnowballsDestroyed++;
               Debug.Log("it is a ray : " + totalSnowballsDestroyed);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != otherSnowball && gameObject != null)
        {
            other.gameObject.GetComponent<CharacterForBlue>().colorChange = true;
            Destroy(gameObject);
            totalSnowballsDestroyed++;
            Debug.Log("it is a hit : " + other.gameObject.name + " " + totalSnowballsDestroyed);
        }
    }
}
