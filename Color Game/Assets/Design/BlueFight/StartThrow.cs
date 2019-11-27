using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartThrow : MonoBehaviour
{
    public static float count;
    public GameObject player;
    Vector3 nextSpot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SnowballScript.totalSnowballsDestroyed == 42 && count == 4)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
        else if (SnowballScript.totalSnowballsDestroyed == 30 && count == 3)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
        else if (SnowballScript.totalSnowballsDestroyed == 18 && count == 2)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
        else if (SnowballScript.totalSnowballsDestroyed == 6 && count == 1)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        count++;
        if (count == 5) Invoke("GoToBase", 2f);
        else
        {
            nextSpot = new Vector3(player.transform.position.x + 10.5f, player.transform.position.y, player.transform.position.z);
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform enemy = transform.GetChild(i);
                enemy.gameObject.GetComponent<EnemyThrow>().StartThrowing();
            }
        }
    }

    void GoToBase()
    {
        SceneManager.LoadScene("MainTown");
    }
}
