using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSpawner : MonoBehaviour
{
    public GameObject theEnemy;
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
        while (enemyCount < 7)
        {
            xPos = Random.Range(20, 80);
            zPos = Random.Range(20, 100);
            Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount++;
        }
    }
}
