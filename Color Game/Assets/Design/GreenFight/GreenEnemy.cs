using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    public GameObject player;
    public GameObject fellowEnemy;
    GameObject fellowEnemy1Clone;
    GameObject fellowEnemy2Clone;
    public float speedNum;
    public bool hydra;
    public bool firstGenHydra;

    void Start()
    {
    }

    void Update()
    {
        //Debug.Log(hydra);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedNum * Time.deltaTime);
    }

    public void FormHydra()
    {
        if (firstGenHydra)
        {
            hydra = false;
            fellowEnemy1Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);
            fellowEnemy1Clone.GetComponent<GreenEnemy>().speedNum = speedNum + 1;
            fellowEnemy2Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
            fellowEnemy2Clone.GetComponent<GreenEnemy>().speedNum = speedNum + 1;
            Destroy(gameObject);
        }
        else
        {
            hydra = false;
            fellowEnemy1Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x - 1, transform.position.y, transform.position.z), transform.rotation);
            fellowEnemy1Clone.GetComponent<GreenEnemy>().speedNum = speedNum + 1;
            fellowEnemy1Clone.GetComponent<GreenEnemy>().hydra = true;
            fellowEnemy1Clone.GetComponent<GreenEnemy>().firstGenHydra = true;
            fellowEnemy2Clone = Instantiate(fellowEnemy, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), transform.rotation);
            fellowEnemy2Clone.GetComponent<GreenEnemy>().speedNum = speedNum + 1;
            fellowEnemy2Clone.GetComponent<GreenEnemy>().hydra = true;
            fellowEnemy2Clone.GetComponent<GreenEnemy>().firstGenHydra = true;
            Destroy(gameObject);
        }
        
    }
}
