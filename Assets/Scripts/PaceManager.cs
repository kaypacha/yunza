using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceManager : MonoBehaviour
{

    public List<string> currentPattern;

    // Start is called before the first frame update
    void Start()
    {
        GeneratePattern(4);
    }

    // Update is called once per frame
    void Update()
    {
        
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
                currentPattern.Add("Red");
                break;
            case 1:
                currentPattern.Add("Green");
                break;
            case 2:
                currentPattern.Add("Blue");
                break;
            case 3:
                currentPattern.Add("Yellow");
                break;
            default:
                break;
        }

        iterations -= 1;
        GeneratePattern(iterations);
    }
}
