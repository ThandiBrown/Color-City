using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterForBlue : MonoBehaviour
{
    public bool colorChange;
    public static float hitCount = 0;
    public static bool bouncy;
    bool once = true;
    Vector3 orgPos, up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (bouncy)
        {
            if (once)
            {
                once = false;
                orgPos = transform.position;
                up = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
                Invoke("GoToBase", 6f);
            }
            float time = Mathf.PingPong(Time.time * 2, 1);
            transform.position = Vector3.Lerp(orgPos, up, time);
        }

        if (colorChange)
        {
            colorChange = false;
            GetComponent<Renderer>().material.color = Color.red;
            Invoke("returnColor", 0.05f);
            Debug.Log(" qqqqqqqqqqqqq" + hitCount);
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
