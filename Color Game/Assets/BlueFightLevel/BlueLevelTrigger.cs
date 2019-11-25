using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLevelTrigger : MonoBehaviour
{
    public static float ballsThrown;
    public static bool moveAlong;
    public static bool startThrowing = false;

    private void OnTriggerEnter(Collider other)
    {
        ballsThrown = 0;
        moveAlong = false;
        startThrowing = true;
        Debug.Log("yyyyyyyyyyyy");
    }
}
    
