using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deletionarea : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }
}
