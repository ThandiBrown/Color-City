using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGoldEnemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;
    bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GoldEnemySpawner.blastOccurred)
        {
            if (once)
            {
                Invoke("DestoryMe", 2.5f);
                once = false;
            }
            transform.position = Vector3.MoveTowards(transform.position, -Vector3.forward, 50f * Time.deltaTime);
        }
        else if (player.transform.position.z > transform.position.z || player != null)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    void DestoryMe()
    {
        GoldEnemySpawner.blastOccurred = false;
        Destroy(gameObject);
        CharacterMovement.moveSpeed = 5;
    }
}
