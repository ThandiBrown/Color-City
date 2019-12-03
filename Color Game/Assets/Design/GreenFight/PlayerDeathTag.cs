using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathTag : MonoBehaviour
{
    public GameObject enemySpawner;
    public GameObject level1Tag;
    public GameObject level2Tag;
    public GameObject level3Tag;
    public GameObject level4Tag;
    public GameObject level5Tag;

    // Start is called before the first frame update
    void StopTime()
    {
        Time.timeScale = 0;
    }

    public void RestartLevel()
    {
        if (GreenSpawner.levelDeath == 1) {
            level1Tag.SetActive(true);
            level1Tag.GetComponent<MessageOne>().Start();
        }
        if (GreenSpawner.levelDeath == 2) {
            level2Tag.SetActive(true);
            level2Tag.GetComponent<MessageTwo>().Start();
        }
        if (GreenSpawner.levelDeath == 3)
        {
            level3Tag.SetActive(true);
            level3Tag.GetComponent<MessageThree>().Start();
        }
        if (GreenSpawner.levelDeath == 4)
        {
            level4Tag.SetActive(true);
            level4Tag.GetComponent<MessageFour>().Start();
        }
        if (GreenSpawner.levelDeath == 5)
        {
            level5Tag.SetActive(true);
            level5Tag.GetComponent<MessageFive>().Start();
        }

        GreenSpawner.levelNum = GreenSpawner.levelDeath - 1;
        Player.greenHitCount = 0;
        enemySpawner.GetComponent<GreenSpawner>().Start();
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainTown");
    }
}
