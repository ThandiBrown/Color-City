using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gotmilk : MonoBehaviour
{
    public GameObject camerar;
    public GameObject earthPiece;
    public float fireRate = 0.5f;
    private float nextFire = 0.0F;
    public float speed = 30;
    GameObject earthPieceClone;
    Transform goo;


    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            goo = Camera.main.transform;
            goo.transform.eulerAngles = new Vector3(-2.5f, goo.transform.eulerAngles.y, goo.transform.eulerAngles.z);
            earthPieceClone = Instantiate(earthPiece, transform.position + goo.forward * 5, Quaternion.Euler(0f, goo.transform.eulerAngles.y, 0f));
            earthPieceClone.transform.position = new Vector3(earthPieceClone.transform.position.x, 0.235f, earthPieceClone.transform.position.z);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
