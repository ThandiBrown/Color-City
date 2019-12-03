using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenStartUp : MonoBehaviour
{
    public GameObject window;
    public GameObject level1Tag;
    public GameObject level2Tag;
    public GameObject level3Tag;
    public GameObject level4Tag;
    public GameObject level5Tag;
    public GameObject playerDeathTag;

    public GameObject enemySpawner;
    public static bool gameStart;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        
        level1Tag.SetActive(false);
        level2Tag.SetActive(false);
        level3Tag.SetActive(false);
        level4Tag.SetActive(false);
        level5Tag.SetActive(false);
        playerDeathTag.GetComponent<PlayerDeathTag>().enemySpawner = enemySpawner;
        playerDeathTag.SetActive(false);
    }

    public void Hide()
    {
        gameStart = true;
        Time.timeScale = 1;
        level1Tag.SetActive(true);
        window.SetActive(false);

        enemySpawner.GetComponent<GreenSpawner>().playerDeathTag = playerDeathTag;
        enemySpawner.GetComponent<GreenSpawner>().level1Tag = level1Tag;
        enemySpawner.GetComponent<GreenSpawner>().level2Tag = level2Tag;
        enemySpawner.GetComponent<GreenSpawner>().level3Tag = level3Tag;
        enemySpawner.GetComponent<GreenSpawner>().level4Tag = level4Tag;
        enemySpawner.GetComponent<GreenSpawner>().level5Tag = level5Tag;

        enemySpawner.GetComponent<GreenSpawner>().Start();

        playerDeathTag.GetComponent<PlayerDeathTag>().level1Tag = level1Tag;
        playerDeathTag.GetComponent<PlayerDeathTag>().level2Tag = level2Tag;
        playerDeathTag.GetComponent<PlayerDeathTag>().level3Tag = level3Tag;
        playerDeathTag.GetComponent<PlayerDeathTag>().level4Tag = level4Tag;
        playerDeathTag.GetComponent<PlayerDeathTag>().level5Tag = level5Tag;

    }
    
}
