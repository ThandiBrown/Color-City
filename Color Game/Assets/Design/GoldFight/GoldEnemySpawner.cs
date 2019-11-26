﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldEnemySpawner : MonoBehaviour
{
    public GameObject rightEnemy;
    public GameObject leftEnemy;
    Vector3 rightEnemyPos;
    Vector3 leftEnemyPos;
    public float r_repeatRate;
    public float l_repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        rightEnemyPos = new Vector3(2.656f, 1f, 0.5f);
        InvokeRepeating("RightEnemySpawner", 1f, r_repeatRate);

        leftEnemyPos = new Vector3(2.656f, 1f, 16.5f);
        InvokeRepeating("LeftEnemySpawner", 1f, l_repeatRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SpearAttack.killCount == 8)
        {
            CancelInvoke("RightEnemySpawner");
            CancelInvoke("LeftEnemySpawner");
            Invoke("goToBase", 2f);
            SpearAttack.killCount = 0;
        }
    }

    void RightEnemySpawner()
    {
        Instantiate(rightEnemy, rightEnemyPos, Quaternion.Euler(0, 0, 0));
    }

    void LeftEnemySpawner()
    {
        Instantiate(leftEnemy, leftEnemyPos, Quaternion.Euler(0, 180, 0));
    }

    void goToBase()
    {
        SceneManager.LoadScene("MainTown");
    }

}