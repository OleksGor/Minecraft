using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool inventoryEnabled;
    public bool collected;
    public GameObject inventory;
    private GameObject[] slot = new GameObject[33];
    public GameObject slotHolder;
   
    private void Start()
    {
        for (var i = 0; i < slot.Length; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            Debug.Log(slot[i]);
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.I))
        {

            inventoryEnabled = !inventoryEnabled;
        }
        if (inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        collected = false;
        if (other.tag == "Item" && other.GetComponent<Item>().broken == true)
        {
            for(int i = 0; i < slot.Length; i++)
            {
                if(!collected && slot[i].GetComponent<Slot>().ID == other.GetComponent<Item>().ID && slot[i].GetComponent<Slot>().amount < 64) {
                    slot[i].GetComponent<Slot>().ID = other.GetComponent<Item>().ID;
                    slot[i].GetComponent<Slot>().icon = other.GetComponent<Item>().icon;
                    slot[i].GetComponent<Slot>().amount += 1;
                    collected = true;
                    Destroy(other.gameObject);
                }
                else if (!collected && slot[i].GetComponent<Slot>().ID == "")
                {
                    slot[i].GetComponent<Slot>().ID = other.GetComponent<Item>().ID;
                    slot[i].GetComponent<Slot>().icon = other.GetComponent<Item>().icon;
                    slot[i].GetComponent<Slot>().amount = 1;
                    collected = true;
                   Destroy(other.gameObject);
                }
            }
        }
    }
}
