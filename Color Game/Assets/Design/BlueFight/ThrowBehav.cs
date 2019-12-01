using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBehav : MonoBehaviour
{
    public static float count;
    public GameObject player;

    Transform enemy1, enemy2, enemy3, enemy4;
    public Transform level2;
    bool look = false, enemyCycleEnd = false;
    Transform[] enemies = new Transform[8];
    // Start is called before the first frame update
    void Start()
    {
        SnowballScript.totalSnowballsDestroyed = 6;
        count = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (SnowballScript.totalSnowballsDestroyed == 6 && count == 1)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
        if (look)
        {
            enemyCycleEnd = enemies[0].GetComponent<EnemyThrow>().finishedThrowing;
            for (int i = 1; i < transform.childCount; i++)
            {
                enemyCycleEnd = enemyCycleEnd && enemies[i].GetComponent<EnemyThrow>().finishedThrowing;
            }
            if (count > 2 && enemyCycleEnd)
            {
                Debug.Log("it's a new one");
                Invoke("MakeThrow", 2f);
                count--;
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        count++;
        gameObject.GetComponent<Collider>().enabled = false;
        if(count == 2)
        {
            MakeThrow();
        }
        
    }

    void MakeThrow()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            enemies[i]  = transform.GetChild(i);
            enemies[i].gameObject.GetComponent<EnemyThrow>().StartThrowing();
        }
        look = true;
        count++;
    }
}
