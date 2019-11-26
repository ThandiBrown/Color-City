using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    public GameObject player;
    public float speedNum;
    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedNum * Time.deltaTime);
    }
}
