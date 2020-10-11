using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorReferencer : MonoBehaviour
{

    public static ColorReferencer instance;
    public Transform red;
    public Transform green;
    public Transform blue;
    public Transform yellow;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Color GetColorRef(string txt)
    {
        Color res = Color.white;
        switch (txt)
        {
            case "Red":
                res = red.GetComponent<SpriteRenderer>().color;
                break;
            case "Blue":
                res = blue.GetComponent<SpriteRenderer>().color;
                break;
            case "Green":
                res = green.GetComponent<SpriteRenderer>().color;
                break;
            case "Yellow":
                res = yellow.GetComponent<SpriteRenderer>().color;
                break;
            default:
                break;
        }

        return res;
    }
}
