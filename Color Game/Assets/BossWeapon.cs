using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    public GameObject target;
    public bool level1, level2, moved;
    static float fcount, ycount;
    // Start is called before the first frame update
    void Start()
    {
        fcount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (level1) transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 20 * Time.deltaTime);
        if (level2) transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 100 * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    void OnMouseDown()
    {
        Debug.Log("click");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2000.0f))
        {
            Debug.Log("wwwwwwwwwwwwwwwwww" + hit.transform.name);
            if (hit.transform.name == "BossWeapon(Clone)")
            {
                
                if (level1) level1 = false;
                if (level2)
                {
                    level2 = false;
                    ycount++;
                }
                hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z + 100);
                moved = true;
                //Destroy(hit.transform.gameObject);
                Debug.Log(" f & y: " + fcount + " " + ycount);
            }
        }
    }
}
