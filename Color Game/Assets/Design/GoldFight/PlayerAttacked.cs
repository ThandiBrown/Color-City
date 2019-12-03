using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttacked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("goToBase", 2f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.name == "LeftEnemy(Clone)" || other.gameObject.transform.name == "RightEnemy(Clone)") Destroy(transform.parent.gameObject);
    }

    void goToBase()
    {
        SceneManager.LoadScene("MainTown");
    }
}
