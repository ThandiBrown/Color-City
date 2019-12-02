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
    bool detectEndOfThrowing = false, enemyCycleEnd = false, shakeItUp = false;
    Transform[] enemies = new Transform[8];
    static Collider currCollider;
    static GameObject theObj;

    bool moveItBack;

    // Start is called before the first frame update
    void Start()
    {
        totalSnowballsDestroyed = 0;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (LevelPassScript.entered && !moveItBack)
        {
            EnablePrevCollider();
            LevelPassScript.entered = false;
        }

        if (CharacterForBlue.hitCount >= 51)
        {
            RespawnCharacter();
        }
        else
        {
            if (totalSnowballsDestroyed == 6 && count == 1)
            {
                //Debug.Log("1g");
                player.transform.Translate(Vector3.right * Time.deltaTime * 8);
            }
            if (totalSnowballsDestroyed == 8 && count == 2)
            {
                //Debug.Log("2g");
                player.transform.Translate(Vector3.right * Time.deltaTime * 8);
            }
            if (totalSnowballsDestroyed == 10 && count == 3)
            {
                //Debug.Log("3g");
                player.transform.Translate(Vector3.right * Time.deltaTime * 8);
            }
            if (totalSnowballsDestroyed == 12 && count == 4)
            {
                //Debug.Log("4g");
                player.transform.Translate(Vector3.right * Time.deltaTime * 8);
            }

            if (detectEndOfThrowing)
            {
                //Debug.Log("detectEndOfThrowingTrue");
                enemyCycleEnd = enemies[0].GetComponent<EnemyThrow>().finishedThrowing;
                for (int i = 1; i < transform.childCount; i++)
                {
                    enemyCycleEnd = enemyCycleEnd && enemies[i].GetComponent<EnemyThrow>().finishedThrowing;
                }
                if (enemyCycleEnd)
                {
                    theCam.GetComponent<CameraShake>().shakeDuration = 1.3f;
                    theCam.GetComponent<CameraShake>().pie = true;
                    boss.GetComponent<BlueBoss>().idle = false;
                    boss.GetComponent<BlueBoss>().NextLevel();
                    enemyCycleEnd = false;
                    detectEndOfThrowing = false;
                    shakeItUp = true;
                }
            }

            if (theCam.GetComponent<CameraShake>().pie && shakeItUp)
            {
                Debug.Log("camShakeTrue");
                shakeItUp = false;

                Invoke("ShakeAndCont", 1.5f);
            }
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (!moveItBack)
        {
            count++;
            theObj = transform.gameObject;
            if (count != 5)
            {
                Debug.Log("TriggerIf");
                totalSnowballsDestroyed = 0;
                Debug.Log("ppppp " + count + " " + totalSnowballsDestroyed);
                currCollider = gameObject.GetComponent<Collider>();
                currCollider.enabled = false;
                MakeThrow();
            }
            else
            {
                Debug.Log("TriggerElse");
                boss.GetComponent<BlueBoss>().idle = false;
                boss.GetComponent<BlueBoss>().player = player;
                boss.transform.Rotate(12, 0, 0);
                boss.GetComponent<BlueBoss>().globalattack1 = true;
            }
        }
        
    }
    
    
    void MakeThrow()
    {
        Debug.Log("MakeThrow");
        Debug.Log("zzzz " + transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            enemies[i]  = transform.GetChild(i);
            if (count == 4) enemies[i].gameObject.GetComponent<EnemyThrow>().wasBouncy = true;
            enemies[i].gameObject.GetComponent<EnemyThrow>().theTarget = player;
            enemies[i].gameObject.GetComponent<EnemyThrow>().StartThrowing();
            
        }
        detectEndOfThrowing = true;
    }

    void ShakeAndCont()
    {
        Debug.Log("ShakeAndCont");
        boss.GetComponent<BlueBoss>().LevelBegin();
        
        if (count == 1) totalSnowballsDestroyed = 6;
        if (count == 2) totalSnowballsDestroyed = 8;
        if (count == 3) totalSnowballsDestroyed = 10;
        if (count == 4) totalSnowballsDestroyed = 12;

        Debug.Log("wwww " + totalSnowballsDestroyed + " " + count);
    }

    void EnablePrevCollider()
    {
        //Debug.Log("LevelPass");
        //Debug.Log(currCollider.gameObject.name);
        currCollider.enabled = true;
    }

    void RespawnCharacter()
    {
        Debug.Log("HitCount Reached");

        moveItBack = true;
        detectEndOfThrowing = false;

        count = 1;
        CharacterForBlue.hitCount = 0;
        player.transform.position = new Vector3(12.25f, 1f, 5.12f);
        

        for (int i = 0; i < theObj.transform.childCount; i++)
        {
            Debug.Log(theObj.name);
            enemies[i] = theObj.transform.GetChild(i);
            if (enemies[i].gameObject.GetComponent<EnemyThrow>().snowballClone != null) enemies[i].gameObject.GetComponent<EnemyThrow>().snowballClone.SetActive(false);
            enemies[i].gameObject.SetActive(false);
            if(theObj.name == "LevelFourEnemies")
            {
                enemies[i].gameObject.GetComponent<EnemyThrow>().wasBouncy = false;
                enemies[i].gameObject.GetComponent<EnemyThrow>().bouncy = false;
                enemies[i].gameObject.transform.position = enemies[i].gameObject.GetComponent<EnemyThrow>().orgPos;
            }
            enemies[i].gameObject.SetActive(true);
        }

        GetComponent<Collider>().enabled = true;
        moveItBack = false;
    }
}
