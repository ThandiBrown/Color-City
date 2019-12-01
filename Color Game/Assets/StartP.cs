using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartP : MonoBehaviour
{
    public ParticleSystem p1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!p1.isPlaying)
            {
                Instantiate(p1,transform.position, Quaternion.Euler(-90, 0, 0));
                p1.GetComponent<PinkStorm>().player = transform.gameObject;
                p1.Play();
            }
        }
    }
}
