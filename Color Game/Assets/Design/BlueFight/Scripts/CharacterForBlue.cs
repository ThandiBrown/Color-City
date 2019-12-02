using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterForBlue : MonoBehaviour
{
    public bool colorChange;
    public static float hitCount = 0;
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("GoToBase", 2f);
        }
    }

    void returnColor()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    void GoToBase()
    {
        SceneManager.LoadScene("MainTown");
    }
}
