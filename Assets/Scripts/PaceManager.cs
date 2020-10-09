using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceManager : MonoBehaviour
{

    public List<string> allPatterns;

    public int currentPattern;

    float currentTime;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePattern(4);
        currentPattern = allPatterns.Count - 1;

        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPattern>= 0)
        {
            if (Time.time - currentTime > timer)
            {
                currentTime = Time.time;
                Debug.Log(allPatterns[currentPattern]);

                currentPattern--;
            }
        } else
        {
            Debug.Log("YOU WIN");
        }
    }

    void GeneratePattern(int iterations)
    {
        if (iterations<= 0)
        {
            return;
        }
        int r = Random.Range(0, 4);
        switch (r)
        {
            case 0:
                allPatterns.Add("Red");
                break;
            case 1:
                allPatterns.Add("Green");
                break;
            case 2:
                allPatterns.Add("Blue");
                break;
            case 3:
                allPatterns.Add("Yellow");
                break;
            default:
                break;
        }

        iterations -= 1;
        GeneratePattern(iterations);
    }
}
