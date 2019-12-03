using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blast : MonoBehaviour
{
    public ParticleSystem blast;
    // Start is called before the first frame update
    public void Start()
    {
        blast.Play();
    }
    
}
