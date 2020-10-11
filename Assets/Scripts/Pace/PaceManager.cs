using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceManager : MonoBehaviour
{
    //Helpers
    public static PaceManager instance;

    //States
    public enum GState { 
        zones,
        axe,
        win,
        lose
    }

    public GState currentState;

    //Patterns
    public int patternAmmount = 4;
    public List<string> allPatterns;

    public int currentPattern;
    public bool hit;
    public GameObject tree;
    public int nForAxe;

    //Timer
    float currentTime;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GeneratePattern(patternAmmount);
        AddAxe(nForAxe-1);

        allPatterns.Reverse();

        NextPattern(allPatterns.Count);
                
        Debug.Log(allPatterns[currentPattern]);
    }

 

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case GState.zones:

                if (currentPattern >= 0)
                {
                    if (Time.time - currentTime > timer)
                    {
                        NextPattern(currentPattern);

                        //Debug.Log(allPatterns[currentPattern]);
                    }
                }
                else
                {
                    Debug.Log("YOU WIN");
                }

                break;
            case GState.axe:
                break;
            case GState.win:
                break;
            case GState.lose:
                break;
            default:
                break;
        }

    }

    Color PatternToColor(string pattern)
    {
        Color res = Color.white;
        switch (pattern)
        {
            case "Red":
                res = Color.red;
                break;
            case "Blue":
                res = Color.blue;
                break;
            case "Green":
                res = Color.green;
                break;
            case "Yellow":
                res = Color.yellow;
                break;
            default:
                break;
        }

        return res;
    }
    void NextPattern(int current)
    {
        currentPattern = current - 1;

        if (currentPattern>=0)
        {
            currentTime = Time.time;

            tree.GetComponent<SpriteRenderer>().color = PatternToColor(allPatterns[currentPattern]);
        } else
        {
            tree.GetComponent<SpriteRenderer>().color = Color.white;
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

    void AddAxe(int current)
    {
        if (current >= allPatterns.Count)
        {
            return;
        } else
        {
            allPatterns[current] = "Axe";

            current += nForAxe;

            AddAxe(current);
        }
    }

    public void CheckPattern(string pattern)
    {
        if (pattern==allPatterns[currentPattern])
        {
            Debug.Log(pattern + " | "+ allPatterns[currentPattern] + " | CORRECTO");
        }
        else
        {
            Debug.Log("GameOver");
        }
    }
}
