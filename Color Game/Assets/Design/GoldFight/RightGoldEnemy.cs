using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGoldEnemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > transform.position.z || player != null)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }
    
}
