using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepBurst : MonoBehaviour
{
    public ParticleSystem myself;
    public GameObject player;
    bool wasPlaying;
    // Start is called before the first frame update
    void Start()
    {
        wasPlaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(!myself.isPlaying && myself != null && wasPlaying)
        {
            Destroy(gameObject);
        }
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("rrr");
        if(other != null && other != player)
        {
            Destroy(other);
        }
    }
}
