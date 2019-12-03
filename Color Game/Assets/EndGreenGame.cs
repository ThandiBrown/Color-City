using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGreenGame : MonoBehaviour
{
    public GameObject window;
    // Start is called before the first frame update
    public void Start()
    {
        Invoke("Hide", 4f);
    }

    public void Hide()
    {
        window.SetActive(false);
        SceneManager.LoadScene("MainTown");
    }
}
