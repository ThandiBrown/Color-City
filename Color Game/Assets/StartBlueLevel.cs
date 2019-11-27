using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlueLevel : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        BlueLevelTrigger.ballsThrown = 0;
        BlueLevelTrigger.count++;
        Debug.Log("count: " + BlueLevelTrigger.count);
    }
}
