using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStarter : MonoBehaviour
{

    public float timer;
    float timestart;

    public Text counter;
    public GameObject toActivate;

    // Start is called before the first frame update
    void Start()
    {
        timestart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        int value = (int)(timestart + timer - Time.time);
        counter.text = value.ToString();

        if (timestart + timer - Time.time <= 0)
        {
            toActivate.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
