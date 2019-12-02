using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBoss : MonoBehaviour
{
    
    public GameObject bossWeapon;
    public GameObject player;


    public bool idle, globalattack1;

    bool attack1, attack2;
    float count = 0;

    GameObject bossWeaponClone;
    Vector3 orgPos, up;
   
    // Start is called before the first frame update
    void Start()
    {
        // lets boss move up and down
        orgPos = transform.position;
        up = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (idle)
        {
            float time = Mathf.PingPong(Time.time * 0.5f, 1);
            transform.position = Vector3.Lerp(orgPos, up, time);
        }

        // globalattack1 triggered by LevelEnd
        if (globalattack1)
        {
            globalattack1 = false;
            attack1 = true;
            ThrowLevelOne();
        }
    }

    public void ThrowLevelOne()
    {
        // 3 soft balls
        if (attack1 && count < 3)
        {
            count++;
            bossWeaponClone = Instantiate(bossWeapon, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
            bossWeaponClone.GetComponent<BossWeapon>().player = player;
            bossWeaponClone.GetComponent<BossWeapon>().level1 = true;
            Invoke("ThrowLevelOne", 1f);
        }
        else if (attack1 && count == 3)
        {
            // start next attack after soft-balls are destroyed 
            if (bossWeaponClone.GetComponent<BossWeapon>().lastBallEnded)
            {
                count = 0;
                attack1 = false;
                attack2 = true;
                ThrowLevelOne();
            }
            else
            {
                Invoke("ThrowLevelOne", 3f);
            }

        }

        // throw 40 balls
        if (attack2 && count < 40)
        {
            count++;
            bossWeaponClone = Instantiate(bossWeapon, new Vector3(transform.position.x, transform.position.y + 5, transform.position.z), transform.rotation);
            bossWeaponClone.GetComponent<BossWeapon>().player = player;
            bossWeaponClone.GetComponent<BossWeapon>().level2 = true;
            Invoke("ThrowLevelOne", 0.15f);
        }
        else if(attack2 && count >= 40)
        {
            Debug.Log("This is the ycount hahahahahah" + BossWeapon.ycount);
            if (BossWeapon.ycount >= 20)
            {
                transform.position = new Vector3(120.59f, 3.51f, 5.07f);
                transform.eulerAngles = new Vector3(-26.872f, -98.11501f, 7.748f);
                CharacterForBlue.bouncy = true;
            }
            else
            {
                count = 0;
                globalattack1 = true;
            }
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

    
}
