using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class watertouch : MonoBehaviour
{

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name != "FPSController")
        {
            if (Vector3.Distance(col.transform.position, transform.position)< 0.9f)
            {
            
                Destroy(gameObject);
            }
        }
    }
}
