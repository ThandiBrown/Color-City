using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoss : MonoBehaviour
{
    public bool idle, globalattack1;
    bool globalattack2, attack1, attack2;
    public GameObject bossWeapon;
    public GameObject target;
    GameObject bossWeaponClone;
    Vector3 orgPos, up;
    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //idle = true;
        orgPos = transform.position;
        up = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        
        //globalattack1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (idle)
        {
            float time = Mathf.PingPong(Time.time * 0.5f, 1);
            transform.position = Vector3.Lerp(orgPos, up, time);
        }

        if (globalattack1)
        {
            globalattack1 = false;
            attack1 = true;
            ThrowLevelOne();
            
        }
        

    }

    public void NextLevel()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        transform.Rotate(20, 0, 0);
    }

    public void LevelBegin()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - 5, transform.position.z);
        transform.Rotate(-20, 0, 0);
    }

    public void ThrowLevelOne()
    {
        if (attack1 && count < 3)
        {
            Debug.Log("y");
            count++;
            bossWeaponClone = Instantiate(bossWeapon, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
            bossWeaponClone.GetComponent<BossWeapon>().target = target;
            bossWeaponClone.GetComponent<BossWeapon>().level1 = true;
            Invoke("ThrowLevelOne", 1f);
        }
        else if(attack1 && count == 3)
        {
            if(bossWeaponClone.GetComponent<BossWeapon>().moved)
            {
                attack1 = false;
                Debug.Log("r");
                count = 0;
                attack2 = true;
                ThrowLevelOne();
            }
            else
            {
                Invoke("ThrowLevelOne", 3f);
            }
            
        }

        if (attack2 && count < 40)
        {
            Debug.Log("v");
            count++;
            bossWeaponClone = Instantiate(bossWeapon, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
            bossWeaponClone.GetComponent<BossWeapon>().target = target;
            bossWeaponClone.GetComponent<BossWeapon>().level2 = true;
            Invoke("ThrowLevelOne", 0.15f);
        }

    }
}
