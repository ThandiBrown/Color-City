using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    AudioSource hitter;
    public AudioClip hitSound;
    public GameObject player;
    public bool level1, level2, lastBallEnded;
    public static float fcount, ycount;
    
    // Start is called before the first frame update
    void Start()
    {
        fcount++;
        hitter = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level1) transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 20 * Time.deltaTime);
        if (level2) transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 100 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (level1)
        {
            level1 = false;
            if (fcount == 3) transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 100);
            else Destroy(gameObject);
        }
        if (level2)
        {
            level2 = false;
            Destroy(gameObject);
        }

        lastBallEnded = true;   
    }

    void OnMouseDown()
    {
        Debug.Log("click");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2000.0f))
        {
            if (hit.transform.name == "BossWeapon(Clone)")
            {
                hitter.PlayOneShot(hitSound, 0.7f);
                GetComponent<Renderer>().enabled = false;
                

                if (level1)
                {
                    level1 = false;
                    if (fcount == 3) hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z + 100);
                    else
                    {
                        hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z + 100);
                        Destroy(hit.transform.gameObject, hitSound.length);
                    }
                }
                if (level2)
                {
                    level2 = false;
                    ycount++;
                    hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z + 100);
                    Destroy(hit.transform.gameObject, hitSound.length);
                }
                //hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z + 100);
                
                lastBallEnded = true;
                Debug.Log(" f & y: " + fcount + " " + ycount);
            }
        }
    }
}
