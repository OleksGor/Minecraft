using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicalPlayer : MonoBehaviour
{
    public bool mode;
    public GameObject F5Camera;
    public GameObject player;
    public GameObject head;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F5))
        {
            mode = !mode;
            Debug.Log("ay");
        }
        if (mode)
        {
            F5Camera.SetActive(true);
            player.SetActive(true);
            head.SetActive(true);

        }
        else
        {
            F5Camera.SetActive(false);
            player.SetActive(false);
            head.SetActive(false);
        }
    }
}
