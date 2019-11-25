using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLevelTrigger : MonoBehaviour
{
    public static float ballsThrown;
    public static bool moveAlong;

    private void OnTriggerEnter(Collider other)
    {
        ballsThrown = 0;
        moveAlong = false;
    }
}
    
