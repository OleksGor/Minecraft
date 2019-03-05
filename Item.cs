using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string ID;
    public Texture2D icon;
    public bool broken;
    private void Update()
    {
        if (broken)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            transform.Rotate(Vector3.up, 4.0f);
            BoxCollider collider = GetComponent<BoxCollider>();
            collider.size = new Vector3(4, 4, 4);

        }
    }

}
