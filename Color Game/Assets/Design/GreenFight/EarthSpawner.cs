﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthSpawner : MonoBehaviour
{
    public GameObject earthPieceBase;
    GameObject earthPiece;
    public GameObject ball;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = Camera.main.ScreenPointToRay(Crosshair.crosshairPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name != "Terrain")
                {
                    ball = hit.transform.gameObject;
                    earthPiece = Instantiate(earthPieceBase, new Vector3(player.transform.position.x, player.transform.position.y - 3, player.transform.position.z + 4), player.transform.rotation);
                    earthPiece.GetComponent<EarthWeapon>().ball = hit.transform.gameObject;
                    earthPiece.GetComponent<EarthWeapon>().player = player;
                }

            }

        }
    }

    void continueAttack()
    {
        Debug.Log("mimp");
        //face = true;
    }
}
