using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject fellowEnemy;
    GameObject fellowEnemy1Clone;
    GameObject fellowEnemy2Clone;
    GameObject fellowEnemy3Clone;
    GameObject fellowEnemy4Clone;
    GameObject fellowEnemy5Clone;
    GameObject fellowEnemy6Clone;
    public float speedNum;
    public bool hydra;
    public bool firstGenHydra;

    void Start()
    {
        
    }

    void Update()
    {
        if (Player.greenHitCount >= 5)
        {
            Destroy(gameObject);
            
            GreenSpawner.enemyDeaths++;
        }
        else transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedNum * Time.deltaTime);
    }

    public void FormHydra()
    {
        if (Player.greenHitCount < 5)
        {
            if (firstGenHydra)
            {
                hydra = false;
                fellowEnemy1Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x - 5, transform.position.y, transform.position.z), transform.rotation);
                fellowEnemy1Clone.GetComponent<GreenEnemy>().speedNum = speedNum;
                fellowEnemy1Clone.transform.localScale = new Vector3(4, 4, 4);
                fellowEnemy1Clone.transform.position = new Vector3(fellowEnemy1Clone.transform.position.x, fellowEnemy1Clone.transform.position.y + 4, fellowEnemy1Clone.transform.position.z);
                fellowEnemy2Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x + 5, transform.position.y, transform.position.z), transform.rotation);
                fellowEnemy2Clone.GetComponent<GreenEnemy>().speedNum = speedNum;
                fellowEnemy2Clone.transform.localScale = new Vector3(4, 4, 4);
                fellowEnemy2Clone.transform.position = new Vector3(fellowEnemy2Clone.transform.position.x, fellowEnemy2Clone.transform.position.y + 4, fellowEnemy2Clone.transform.position.z);


                fellowEnemy3Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x - 10, transform.position.y, transform.position.z), transform.rotation);
                fellowEnemy3Clone.GetComponent<GreenEnemy>().speedNum = speedNum;
                fellowEnemy3Clone.transform.localScale = new Vector3(4, 4, 4);
                fellowEnemy3Clone.transform.position = new Vector3(fellowEnemy3Clone.transform.position.x, fellowEnemy3Clone.transform.position.y + 4, fellowEnemy3Clone.transform.position.z);
                fellowEnemy4Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x + 10, transform.position.y, transform.position.z), transform.rotation);
                fellowEnemy4Clone.GetComponent<GreenEnemy>().speedNum = speedNum;
                fellowEnemy4Clone.transform.localScale = new Vector3(4, 4, 4);
                fellowEnemy4Clone.transform.position = new Vector3(fellowEnemy4Clone.transform.position.x, fellowEnemy4Clone.transform.position.y + 4, fellowEnemy4Clone.transform.position.z);

                fellowEnemy5Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x - 15, transform.position.y, transform.position.z), transform.rotation);
                fellowEnemy5Clone.GetComponent<GreenEnemy>().speedNum = speedNum;
                fellowEnemy5Clone.transform.localScale = new Vector3(4, 4, 4);
                fellowEnemy5Clone.transform.position = new Vector3(fellowEnemy5Clone.transform.position.x, fellowEnemy5Clone.transform.position.y + 4, fellowEnemy5Clone.transform.position.z);
                fellowEnemy6Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x + 15, transform.position.y, transform.position.z), transform.rotation);
                fellowEnemy6Clone.GetComponent<GreenEnemy>().speedNum = speedNum;
                fellowEnemy6Clone.transform.localScale = new Vector3(4, 4, 4);
                fellowEnemy6Clone.transform.position = new Vector3(fellowEnemy6Clone.transform.position.x, fellowEnemy6Clone.transform.position.y + 4, fellowEnemy6Clone.transform.position.z);
                GreenSpawner.enemiesAlive.Add(fellowEnemy1Clone);
                GreenSpawner.enemiesAlive.Add(fellowEnemy2Clone);
                GreenSpawner.enemiesAlive.Add(fellowEnemy3Clone);
                GreenSpawner.enemiesAlive.Add(fellowEnemy4Clone);
                GreenSpawner.enemiesAlive.Add(fellowEnemy5Clone);
                GreenSpawner.enemiesAlive.Add(fellowEnemy6Clone);
                GreenSpawner.enemyDeaths++;
                Destroy(gameObject);
            }
            else
            {
                hydra = false;
                fellowEnemy1Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x - 3, transform.position.y, transform.position.z), transform.rotation);
                fellowEnemy1Clone.GetComponent<GreenEnemy>().speedNum = speedNum;
                fellowEnemy1Clone.GetComponent<GreenEnemy>().hydra = true;
                fellowEnemy1Clone.GetComponent<GreenEnemy>().firstGenHydra = true;
                fellowEnemy1Clone.transform.localScale = new Vector3(2, 2, 2);
                fellowEnemy1Clone.transform.position = new Vector3(fellowEnemy1Clone.transform.position.x, fellowEnemy1Clone.transform.position.y + 2, fellowEnemy1Clone.transform.position.z);
                fellowEnemy2Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x + 3, transform.position.y, transform.position.z), transform.rotation);
                fellowEnemy2Clone.GetComponent<GreenEnemy>().speedNum = speedNum;
                fellowEnemy2Clone.GetComponent<GreenEnemy>().hydra = true;
                fellowEnemy2Clone.GetComponent<GreenEnemy>().firstGenHydra = true;
                fellowEnemy2Clone.transform.localScale = new Vector3(2, 2, 2);
                fellowEnemy2Clone.transform.position = new Vector3(fellowEnemy2Clone.transform.position.x, fellowEnemy2Clone.transform.position.y + 2, fellowEnemy2Clone.transform.position.z);
                GreenSpawner.enemiesAlive.Add(fellowEnemy1Clone);
                GreenSpawner.enemiesAlive.Add(fellowEnemy2Clone);
                GreenSpawner.enemyDeaths++;
                Destroy(gameObject);
            }
        }
        
        
    }
}
