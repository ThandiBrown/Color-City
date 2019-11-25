using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGoldEnemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z < transform.position.z)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject == player.transform.GetChild(0)) Destroy(other.gameObject.transform.parent);
    }
}
