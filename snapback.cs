using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snapback : MonoBehaviour
{

    void Start()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z));
        transform.rotation = Quaternion.identity;
    }
}