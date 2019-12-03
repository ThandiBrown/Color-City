﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSpawner : MonoBehaviour
{
    public GameObject theEnemy;
    GameObject enemyClone;
    public int xPos;
    public int zPos;
    public int enemyCount;

    int levelNum;

    // Start is called before the first frame update
    void Start()
    {
        levelNum = 5;
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    IEnumerator EnemyDrop()
    {
        if (levelNum == 1)
        {
            enemyCount = 0;
            while (enemyCount < 3)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(25, 40);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(5, 6);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 5)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(40, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(6, 7);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 7)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(7, 9);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
        }

        if (levelNum == 2)
        {
            enemyCount = 0;
            while (enemyCount < 4)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(25, 40);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(5, 6);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 8)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(40, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(6, 7);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 11)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(7, 9);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
        }

        if (levelNum == 3)
        {
            enemyCount = 0;
            while (enemyCount < 3)
            {
                xPos = Random.Range(10, 20);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(6, 9);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 6)
            {
                xPos = Random.Range(30, 40);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(10, 11);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 9)
            {
                xPos = Random.Range(50, 60);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(16, 17);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 12)
            {
                xPos = Random.Range(70, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(3, 5);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 15)
            {
                xPos = Random.Range(20, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(6, 7);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
        }

        if (levelNum == 4)
        {
            enemyCount = 0;
            EarthWeapon.speed = 50f;
            while (enemyCount < 1)
            {
                //xPos = Random.Range(30, 40);
                //zPos = Random.Range(50, 60);
                enemyClone = Instantiate(theEnemy, new Vector3(50, 2, 80), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().hydra = true;
                enemyClone.GetComponent<GreenEnemy>().speedNum = 4.5f;
                
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
        }

        if (levelNum == 5)
        {
            enemyCount = 0;
            EarthWeapon.speed = 100f;
            // hydra
            while (enemyCount < 1)
            {
                enemyClone = Instantiate(theEnemy, new Vector3(20, 2, 90), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().hydra = true;
                enemyClone.GetComponent<GreenEnemy>().speedNum = 3;

                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            //cluster
            while (enemyCount < 4)
            {
                xPos = Random.Range(30, 35);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, 40), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = 6;
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            //cluster
            while (enemyCount < 6)
            {
                xPos = Random.Range(60, 65);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, 80), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = 7;
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            //cluster
            while (enemyCount < 9)
            {
                xPos = Random.Range(40, 45);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, 50), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = 4;
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }

            //speeders
            while (enemyCount < 12)
            {
                xPos = Random.Range(20, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(10, 11);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            //randoms
            while (enemyCount < 18)
            {
                xPos = Random.Range(40, 60);
                zPos = Random.Range(50, 70);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);

                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(4, 5);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            
            //cluster
            while (enemyCount < 22)
            {
                xPos = Random.Range(70, 80);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, 50), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = 4;
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
        }
    }
}
