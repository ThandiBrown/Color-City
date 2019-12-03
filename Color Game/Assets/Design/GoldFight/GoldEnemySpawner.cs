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
    public GameObject blast;
    GameObject blastClone; 
    float level;
    public GameObject player;
    public static bool blastOccurred;

    bool next;
    int blastReq = 10;
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
        if (SpearAttack.killCount == blastReq)
        {
            blastClone = Instantiate(blast, player.transform.position, Quaternion.Euler(0,0,0));
            blastOccurred = true;
            CharacterMovement.moveSpeed = 0;
            SpearAttack.killCount = 0;
            next = !next;
            blastReq = blastReq + 5;
            //for (int i = 0; i < blast.transform.childCount; i++)
            //{
            //blastClone.transform.GetChild(i).GetComponent<Blast>().Start();
            //}
            //CancelInvoke("RightEnemySpawner");
            //CancelInvoke("LeftEnemySpawner");
            //Invoke("goToBase", 2f);
            //SpearAttack.killCount = 0;
        }
        if(blastReq == 25)
        {
            Debug.Log("Game Over!");
            Invoke("goToBase", 6f);
        }
    }

    void RightEnemySpawner()
    {
        if (!next)
        {
            // make and set speed
            right = Instantiate(rightEnemy, rightEnemyPos, Quaternion.Euler(0, 0, 0));
            right.GetComponent<RightGoldEnemy>().moveSpeed = Random.Range(1, 3);

            // invoke again in random time
            float randomTime = Random.Range(0.5f, 2.5f);
            Invoke("RightEnemySpawner", randomTime);
        }
        else
        {
            // make and set speed
            right = Instantiate(rightEnemy, rightEnemyPos, Quaternion.Euler(0, 0, 0));
            right.GetComponent<RightGoldEnemy>().moveSpeed = Random.Range(2, 4);

            // invoke again in random time
            float randomTime = Random.Range(1f, 3f);
            Invoke("RightEnemySpawner", randomTime);
        }
        
    }

    void LeftEnemySpawner()
    {
        if (!next)
        {
            // make and set speed
            left = Instantiate(leftEnemy, leftEnemyPos, Quaternion.Euler(0, 180, 0));
            left.GetComponent<LeftGoldEnemy>().moveSpeed = Random.Range(2, 4);

            // invoke again in random time
            float randomTime = Random.Range(1f, 3f);
            Invoke("LeftEnemySpawner", randomTime);
        }
        else
        {
            // make and set speed
            left = Instantiate(leftEnemy, leftEnemyPos, Quaternion.Euler(0, 180, 0));
            left.GetComponent<LeftGoldEnemy>().moveSpeed = Random.Range(1, 3);

            // invoke again in random time
            float randomTime = Random.Range(0.5f, 2.5f);
            Invoke("LeftEnemySpawner", randomTime);
        }
    }
        


    void goToBase()
    {
        SceneManager.LoadScene("MainTown");
    }

}
