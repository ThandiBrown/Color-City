using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueLevelTrigger : MonoBehaviour
{
    public static float ballsThrown;
    public static float count = 0;
    public GameObject theTarget;
    public static float destroyedSnowballs = 0;

    void Update()
    {
        if(count == 1 && destroyedSnowballs == 6)
        {
            theTarget.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
        if (count == 2 && destroyedSnowballs == 12)
        {
            theTarget.transform.Translate(Vector3.right * Time.deltaTime * 4);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        BlueLevelTrigger.ballsThrown = 0;
        Invoke("Counter", 0.3f);
    }

    void GoToBase()
    {
        SceneManager.LoadScene("MainTown");
    }

    void Counter()
    {
        count++;
        if (count == 3) Invoke("GoToBase", 2f);
        Debug.Log("count: " + count);
        Debug.Log("yyyyyyyyyyyy");
    }
}
    
