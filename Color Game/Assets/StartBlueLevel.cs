using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBlueLevel : MonoBehaviour
{
    public GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    public void Hide()
    {
        Time.timeScale = 1;
        window.SetActive(false);
    }
}
