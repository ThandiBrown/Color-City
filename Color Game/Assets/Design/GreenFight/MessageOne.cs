using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageOne : MonoBehaviour
{
    public GameObject window;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Hide", 2f);
    }
    
    public void Hide()
    {
        window.SetActive(false);
    }
}
