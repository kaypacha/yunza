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
        wait,
        win,
        lose
    }

    public GState currentState;

    //Patterns
    public int patternAmmount = 4;
    public List<string> allPatterns;

    public int currentPattern;
    public bool hit;
    public List<int> nForAxe;

    //Axe
    public GameObject tree;
    public GameObject treePrompt;
    public int nHits;
    int currentHits;
    public float waitAferAxe;


    //Timer
    float currentTime;
    public float timer;
    public float axeTimer;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GeneratePattern(patternAmmount);
        AddAxe();

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
                        if (hit)
                        {
                            NextPattern(currentPattern);
                            if (allPatterns[currentPattern] == "Axe")
                            {
                                currentState = GState.axe;
                                treePrompt.SetActive(true);
                                currentHits = 0;
                                tree.GetComponent<SpriteRenderer>().color = Color.white;
                            }
                        } else
                        {
                            tree.GetComponent<SpriteRenderer>().color = Color.white;
                            Debug.Log("GameOver");
                        }
                    }
                }
                else
                {
                    Debug.Log("YOU WIN");
                }

                break;
            case GState.axe:
                if (Time.time - currentTime > axeTimer)
                {
                    if (currentHits >= nHits)
                    {
                        if (currentPattern > 0)
                        {
                            currentTime = Time.time;
                            currentState = GState.wait;
                            treePrompt.SetActive(false);
                        } else
                        {
                            Debug.Log("YOU WIN AXE");
                        }
                        
                    }else
                    {
                        tree.GetComponent<SpriteRenderer>().color = Color.white;
                        Debug.Log("GAME OVER AXE");
                    }
                }
                break;
            case GState.win:
                break;
            case GState.lose:
                break;
            case GState.wait:
                if (Time.time - currentTime > waitAferAxe)
                {
                    currentState = GState.zones;
                    NextPattern(currentPattern);
                }
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
        hit = false;

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

        if (allPatterns.Count>1)
        {
            CheckPatternDup();
        }
        

        iterations -= 1;
        GeneratePattern(iterations);
    }

    void CheckPatternDup()
    {
        while (allPatterns[allPatterns.Count-1] == allPatterns[allPatterns.Count - 2])
        {
            int r = Random.Range(0, 4);
            switch (r)
            {
                case 0:
                    allPatterns[allPatterns.Count - 1] = "Red";
                    break;
                case 1:
                    allPatterns[allPatterns.Count - 1] = "Green";
                    break;
                case 2:
                    allPatterns[allPatterns.Count - 1] = "Blue";
                    break;
                case 3:
                    allPatterns[allPatterns.Count - 1] = "Yellow";
                    break;
                default:
                    break;
            }
        }
    }

    void AddAxe()
    {
        for (int i = 0; i < nForAxe.Count; i++)
        {
            allPatterns[nForAxe[i]] = "Axe";
        }
    }

    public void CheckPattern(string pattern)
    {
        if (currentState == GState.zones)
        {
            if (pattern == allPatterns[currentPattern])
            {
                hit = true;
                Debug.Log(pattern + " | " + allPatterns[currentPattern] + " | CORRECTO");
            }
            else
            {
                Debug.Log("GameOver");
            }
        }
    }

    public void SwingAxe()
    {
        currentHits++;
        Debug.LogWarning(currentHits);
    }
}
