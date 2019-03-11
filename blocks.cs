using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
    public static Dictionary<string, GameObject> block = new Dictionary<string, GameObject>();
    public GameObject[] BLOCKS;

    void Start()
    {
        for(int i = 0; i < BLOCKS.Length; i++)
        {
            block.Add(BLOCKS[i].name, BLOCKS[i]);
        }
    }
}
