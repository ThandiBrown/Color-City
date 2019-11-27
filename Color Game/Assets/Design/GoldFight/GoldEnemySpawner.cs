using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldEnemySpawner : MonoBehaviour
{
    public GameObject rightEnemy;
    public GameObject leftEnemy;
    GameObject right;
    GameObject left;
    Vector3 rightEnemyPos;
    Vector3 leftEnemyPos;
    public float r_repeatRate;
    public float l_repeatRate;

    // Start is called before the first frame update
    void Start()
    {
        rightEnemyPos = new Vector3(2.656f, 1f, 0.5f);
        Invoke("RightEnemySpawner", 0.5f);

        leftEnemyPos = new Vector3(2.656f, 1f, 16.5f);
        Invoke("LeftEnemySpawner", 0.5f);
        
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
        float randomTime = Random.Range(0.5f, 2.5f);
        right = Instantiate(rightEnemy, rightEnemyPos, Quaternion.Euler(0, 0, 0));
        right.GetComponent<RightGoldEnemy>().moveSpeed = Random.Range(1, 3);
        Invoke("RightEnemySpawner", randomTime);
    }

    void LeftEnemySpawner()
    {
        float randomTime = Random.Range(0.5f, 2.5f);
        left = Instantiate(leftEnemy, leftEnemyPos, Quaternion.Euler(0, 180, 0));
        left.GetComponent<LeftGoldEnemy>().moveSpeed = Random.Range(2, 4);
        Invoke("LeftEnemySpawner", randomTime);
    }

    void goToBase()
    {
        SceneManager.LoadScene("MainTown");
    }

}
