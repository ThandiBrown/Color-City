using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSpawner : MonoBehaviour
{
    public GameObject theEnemy;
    GameObject enemyClone;
    public int xPos;
    public int zPos;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    // Update is called once per frame
    IEnumerator EnemyDrop()
    {
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
}
