using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockstuff : MonoBehaviour
{
    public GameObject rayBlock;
    public bool hit;
    public float reach;
    public float moved;
    public bool moving;
    public bool breaking;
    public GameObject player;
    void Start()
    {

    }

    void Update()
    {

        hit = false;

        if (Input.GetMouseButtonDown(0))
        {
            moving = true;
            breaking = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            moving = true;
            breaking = false;
        }
        if (moved >= reach)
        {
            moved = 0;
            moving = false;
            rayBlock.transform.localPosition = new Vector3(0, 0, 0);
        }
        if (moving && reach > moved)
        {
            moved += 1.0f;
            rayBlock.transform.localPosition = new Vector3(0, 0, moved);

        }


    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name != "FPSController")
        {
            if (breaking)
            {
                col.GetComponent<Item>().broken = true;
            }
            else
            {
                if (Vector3.Distance(player.transform.position, new Vector3(Mathf.Round(rayBlock.transform.position.x), Mathf.Round(rayBlock.transform.position.y), Mathf.Round(rayBlock.transform.position.z))) > 1.5f)
                {
                    moved -= 1.0f;
                    rayBlock.transform.localPosition = new Vector3(0, 0, moved);
                    GameObject block5 = Instantiate(blocks.block["Stone"]);
                    block5.transform.position = new Vector3(Mathf.Round(rayBlock.transform.position.x), Mathf.Round(rayBlock.transform.position.y), Mathf.Round(rayBlock.transform.position.z));
                }
            }
            rayBlock.transform.localPosition = new Vector3(0, 0, 0);
            moving = false;
            moved = 0;
        }
    }


}
