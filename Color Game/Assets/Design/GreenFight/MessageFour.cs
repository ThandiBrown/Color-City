using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageFour : MonoBehaviour
{
    public GameObject window;
    // Start is called before the first frame update
    public void Start()
    {
        Invoke("Hide", 2f);
    }

    public void Hide()
    {
        window.SetActive(false);
    }
}
