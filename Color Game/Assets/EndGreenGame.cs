using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGreenGame : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Start()
    {
        //sInvoke("Hide", 4f);
    }

    public void Hide()
    {
        SceneManager.LoadScene("MainTown");
    }
}
