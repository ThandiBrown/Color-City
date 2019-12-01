using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkStorm : MonoBehaviour
{
    public Vector3 speed;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 5f * Time.deltaTime);
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("detected");
        other.transform.Rotate(-90, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}
