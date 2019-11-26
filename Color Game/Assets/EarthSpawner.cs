using System.Collections;
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
        /*
        if (rise)
        {
            earthPiece.transform.position = Vector3.MoveTowards(earthPiece.transform.position, risePos, 5f * Time.deltaTime);

            if (earthPiece.transform.position.y >= risePos.y)
            {
                rise = false;
                Invoke("continueAttack", 0.4f);
            }
        }

        if (face)
        {
            if (goTowards) Debug.Log("oof");
            earthPiece.transform.LookAt(ball.transform, Vector3.up);

            Vector3 dirFromAtoB = (ball.transform.position - earthPiece.transform.position).normalized;
            float dotProd = Vector3.Dot(dirFromAtoB, earthPiece.transform.forward);

            if (dotProd > 0.9)
            {
                Debug.Log("closer");
                face = false;
                goTowards = true;
            }
        }

        if (goTowards)
        {
            if (earthPiece != null && ball != null)
            {
                earthPiece.transform.position = Vector3.MoveTowards(earthPiece.transform.position, ball.transform.position, 25f * Time.deltaTime);
            }
            else
            {
                goTowards = false;
                Debug.Log("hit");
            }
                
        }
        */
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.name != "Terrain")
                {
                    //Debug.Log(hit.transform.gameObject.name);
                    ball = hit.transform.gameObject;
                    //Debug.Log("ball info: " + ball.name);
                    //rise = true;
                    //goTowards = true;
                    earthPiece = Instantiate(earthPieceBase, new Vector3(player.transform.position.x, player.transform.position.y - 3, player.transform.position.z + 3), player.transform.rotation);
                    earthPiece.GetComponent<EarthWeapon>().ball = hit.transform.gameObject;
                    earthPiece.GetComponent<EarthWeapon>().player = player;
                    //Debug.Log("click: " );
                    //risePos = new Vector3(player.transform.position.x, earthPiece.transform.position.y + 3, player.transform.position.z + 3);
                    //if (hit.transform.name == "Snowball(Clone)") Destroy(hit.transform.gameObject);
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
