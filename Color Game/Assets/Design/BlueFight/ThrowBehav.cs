using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBehav : MonoBehaviour
{
    public static float count;
    public GameObject player;
    public GameObject theCam;
    public GameObject boss;
    float totalSnowballsDestroyed;
    Transform enemy1, enemy2, enemy3, enemy4;
    bool look = false, enemyCycleEnd = false, shakeItUp = false, bossLevelActive;
    Transform[] enemies = new Transform[8];
    
    // Start is called before the first frame update
    void Start()
    {
        totalSnowballsDestroyed = 4;
        count = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (totalSnowballsDestroyed == 6 && count == 1)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 8);
        }
        if (totalSnowballsDestroyed == 8 && count == 2)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 8);
        }
        if (totalSnowballsDestroyed == 10 && count == 3)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 8);
        }
        if (totalSnowballsDestroyed == 12 && count == 4)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 8);
        }

        if (look)
        {
            enemyCycleEnd = enemies[0].GetComponent<EnemyThrow>().finishedThrowing;
            for (int i = 1; i < transform.childCount; i++)
            {
                enemyCycleEnd = enemyCycleEnd && enemies[i].GetComponent<EnemyThrow>().finishedThrowing;
            }
            if (enemyCycleEnd)
            {
                theCam.GetComponent<CameraShake>().shakeDuration = 2f;
                theCam.GetComponent<CameraShake>().pie = true;
                boss.GetComponent<BlueBoss>().idle = false;
                boss.GetComponent<BlueBoss>().NextLevel();
                enemyCycleEnd = false;
                look = false;
                shakeItUp = true;
            }
        }

        if (theCam.GetComponent<CameraShake>().pie && shakeItUp)
        {
            shakeItUp = false;
            
            Invoke("ShakeAndCont", 3f);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        count++;
        if (count != 5)
        {
            Debug.Log("ppppp " + count);
            gameObject.GetComponent<Collider>().enabled = false;
            MakeThrow();
        }
        else
        {
            
            bossLevelActive = true;
            boss.GetComponent<BlueBoss>().idle = false;
            boss.transform.Rotate(20, 0, 0);
            boss.GetComponent<BlueBoss>().globalattack1 = true;
            
        }
        

    }

    void MakeThrow()
    {
        Debug.Log("eee " + transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            enemies[i]  = transform.GetChild(i);
            if (count == 4) enemies[i].gameObject.GetComponent<EnemyThrow>().wasBouncy = true;
            enemies[i].gameObject.GetComponent<EnemyThrow>().theTarget = player;
            enemies[i].gameObject.GetComponent<EnemyThrow>().StartThrowing();
            
        }
        look = true;
    }

    void ShakeAndCont()
    {
        boss.GetComponent<BlueBoss>().LevelBegin();
        if (count == 1) totalSnowballsDestroyed = 6;
        if (count == 2) totalSnowballsDestroyed = 8;
        if (count == 3) totalSnowballsDestroyed = 10;
        if (count == 4) totalSnowballsDestroyed = 12;

        Debug.Log("wwww " + totalSnowballsDestroyed + " " + count);
    }

}
