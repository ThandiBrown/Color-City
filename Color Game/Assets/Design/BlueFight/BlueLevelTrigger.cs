using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueLevelTrigger : MonoBehaviour
{
    public static float ballsThrown;
    public static bool moveAlong;
    public static bool startThrowing = false;
    static float count = 0;
    public static bool closeOut = false;
    
    private void OnTriggerEnter(Collider other)
    {
        ballsThrown = 0;
        moveAlong = false;
        count++;
        if (count == 3) Invoke("goToBase", 2f);
        Debug.Log("count: " + count);
        startThrowing = true;
        Debug.Log("yyyyyyyyyyyy");
    }

    void goToBase()
    {
        SceneManager.LoadScene("MainTown");
    }
}
    
