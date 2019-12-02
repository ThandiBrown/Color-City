using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterForBlue : MonoBehaviour
{
    public bool colorChange;
    public float hitCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colorChange)
        {
            colorChange = false;
            GetComponent<Renderer>().material.color = Color.red;
            Invoke("returnColor", 0.05f);
            hitCount++;
        }
    }

    void returnColor()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
