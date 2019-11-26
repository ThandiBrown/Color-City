using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    public GameObject player;
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5f * Time.deltaTime);
    }
}
