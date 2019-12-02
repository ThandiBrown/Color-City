using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBehav : MonoBehaviour
{
    public static float count;
    public GameObject player;

    Transform enemy1, enemy2, enemy3, enemy4;
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
        if (SnowballScript.totalSnowballsDestroyed == 6 && count == 2)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
        if (SnowballScript.totalSnowballsDestroyed == 6 && count == 3)
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
            if (count > 4 && enemyCycleEnd)
            {
                Debug.Log("it's a new one");
                Invoke("MakeThrow", 15f);
                count--;
            }
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        count++;
        Debug.Log("ppppp " + count);
        gameObject.GetComponent<Collider>().enabled = false;
        if(count == 4)
        {
            MakeThrow();
        }
        
    }

    void MakeThrow()
    {
        Debug.Log("eeeee " + transform.childCount);
        for (int i = 0; i < transform.childCount; i++)
        {
            enemies[i]  = transform.GetChild(i);
            enemies[i].gameObject.GetComponent<EnemyThrow>().StartThrowing();
        }
        look = true;
        count++;
    }
}
