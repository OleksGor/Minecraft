using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Slot : MonoBehaviour
{
    public int amount;
    public Texture2D icon;
    public string ID = "";
    public GameObject image;
    public GameObject text;

    private void Start()
    {
        image = GameObject.Find(gameObject.name+"/RawImage");
        text = GameObject.Find(gameObject.name + "/Text");
        text.GetComponent<RectTransform>().position = new Vector2(440, 100);
    }

    private void Update()
    {
        if (amount < 2)
        {
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
        }
        else
        {
            text.GetComponent<RectTransform>().sizeDelta = new Vector2(160, 30);
        }
        text.GetComponent<Text>().text = amount.ToString();
        image.GetComponent<RawImage>().texture = icon;
        if (ID == "")
        {
            image.GetComponent<RectTransform>().sizeDelta = new Vector2(0,0);
        }
        else
        {
            image.GetComponent<RectTransform>().sizeDelta = new Vector2(50, 50);
        }
    }
}
