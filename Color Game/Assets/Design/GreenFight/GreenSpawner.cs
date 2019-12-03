using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GreenSpawner : MonoBehaviour
{
    public GameObject theEnemy;
    GameObject enemyClone;
    public int xPos;
    public int zPos;
    public int enemyCount;
    public static int enemyDeaths;
    public static int levelNum;
    public static int levelDeath;
    public static ArrayList enemiesAlive = new ArrayList();
    bool gameRunning;
    public GameObject level1Tag;
    public GameObject level2Tag;
    public GameObject level3Tag;
    public GameObject level4Tag;
    public GameObject level5Tag;
    public GameObject playerDeathTag;
    public GameObject endingTag;

    static bool goodTogo;
    // Start is called before the first frame update
    public void Start()
    {
        if (GreenStartUp.gameStart)
        {
            Debug.Log("lalalla");
            gameRunning = true;
            levelNum++;
            StartCoroutine(EnemyDrop());
        }
        
    }

    
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
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 5)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(40, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(6, 7);
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 7)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(7, 9);
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
        }

        if (levelNum == 2)
        {
            Debug.Log("fffff");
            enemyCount = 0;
            while (enemyCount < 4)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(25, 40);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(5, 6);
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 8)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(40, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(6, 7);
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 11)
            {
                xPos = Random.Range(25, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(7, 9);
                enemiesAlive.Add(enemyClone);
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
                enemiesAlive.Add(enemyClone);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(6, 9);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 6)
            {
                xPos = Random.Range(30, 40);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemiesAlive.Add(enemyClone);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(10, 11);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 9)
            {
                xPos = Random.Range(50, 60);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemiesAlive.Add(enemyClone);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(16, 17);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 12)
            {
                xPos = Random.Range(70, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemiesAlive.Add(enemyClone);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(3, 5);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            while (enemyCount < 15)
            {
                xPos = Random.Range(20, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemiesAlive.Add(enemyClone);
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
                enemiesAlive.Add(enemyClone);
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
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            //cluster
            while (enemyCount < 4)
            {
                xPos = Random.Range(30, 35);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, 40), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = 6;
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            //cluster
            while (enemyCount < 6)
            {
                xPos = Random.Range(60, 65);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, 80), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = 7;
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            //cluster
            while (enemyCount < 9)
            {
                xPos = Random.Range(40, 45);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, 50), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = 4;
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }

            //speeders
            while (enemyCount < 13)
            {
                xPos = Random.Range(20, 80);
                zPos = Random.Range(80, 100);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemiesAlive.Add(enemyClone);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(10, 11);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            //randoms
            while (enemyCount < 19)
            {
                xPos = Random.Range(40, 60);
                zPos = Random.Range(50, 70);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, zPos), Quaternion.identity);
                enemiesAlive.Add(enemyClone);
                enemyClone.GetComponent<GreenEnemy>().speedNum = Random.Range(4, 5);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            
            //cluster
            while (enemyCount < 23)
            {
                xPos = Random.Range(70, 80);
                enemyClone = Instantiate(theEnemy, new Vector3(xPos, 2, 50), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().speedNum = 4;
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
            // hydra
            while (enemyCount < 24)
            {
                enemyClone = Instantiate(theEnemy, new Vector3(75, 2, 200), Quaternion.identity);
                enemyClone.GetComponent<GreenEnemy>().hydra = true;
                enemyClone.GetComponent<GreenEnemy>().speedNum = 3.5f;
                enemiesAlive.Add(enemyClone);
                yield return new WaitForSeconds(0.1f);
                enemyCount++;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("goToBase", 2f);
        }

        goodTogo = true;
        for (int i = 0; i < enemiesAlive.Count; i++)
        {
            if ((enemiesAlive[i] + "yes") == "nullyes") goodTogo = goodTogo && true;
            else goodTogo = goodTogo && false;
        }

        if (gameRunning)
        {
            if (Player.greenHitCount >= 5)
            {
                levelDeath = levelNum;
                playerDeathTag.SetActive(true);
                gameRunning = false;
            }
            else
            {
                if (enemyDeaths >= 7 && levelNum == 1 && goodTogo && Player.greenHitCount < 5)
                {
                    goodTogo = false;
                    enemyDeaths = 0;
                    level2Tag.SetActive(true);
                    level2Tag.GetComponent<MessageTwo>().Start();
                    Invoke("Start", 2f);
                    Debug.Log("wewewewe");
                }
                else if (enemyDeaths >= 11 && levelNum == 2 && goodTogo && Player.greenHitCount < 5)
                {
                    goodTogo = false;
                    enemyDeaths = 0;
                    level3Tag.SetActive(true);
                    level3Tag.GetComponent<MessageThree>().Start();
                    Invoke("Start", 2f);
                    Debug.Log("dfdfdfdf");
                }
                else if (enemyDeaths >= 15 && levelNum == 3 && goodTogo && Player.greenHitCount < 5)
                {
                    goodTogo = false;
                    enemyDeaths = 0;
                    level4Tag.SetActive(true);
                    level4Tag.GetComponent<MessageFour>().Start();
                    Invoke("Start", 2f);
                    Debug.Log("thththth");
                }
                else if (enemyDeaths >= 7 && levelNum == 4 && goodTogo && Player.greenHitCount < 5)
                {
                    goodTogo = false;
                    enemyDeaths = 0;
                    level5Tag.SetActive(true);
                    level5Tag.GetComponent<MessageFive>().Start();
                    Invoke("Start", 2f);
                    Debug.Log("qsqsqsqsq");
                }
                else if (enemyDeaths >= 28 && levelNum == 5 && goodTogo && Player.greenHitCount < 5)
                {
                    enemyDeaths = 0;
                    Debug.Log("Game Over");
                    endingTag.SetActive(true);
                }

            }
        }

    }

    void goToBase()
    {
        
        SceneManager.LoadScene("MainTown");
        
    }
}
