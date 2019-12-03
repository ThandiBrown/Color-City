using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpWindown : MonoBehaviour
{
    public GameObject window;
    public Text messageField;

    // Start is called before the first frame update
    public void Show(string message)
    {
        messageField.text = message;
    }

    public void Hide()
    {
        window.SetActive(false);
    }
}
