using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int currentHits;
    public int GetCurrentHits() { return currentHits; }
    public float waitAferAxe;


    //Timer
    float currentTime;
    public float timer;
    public float axeTimer;
    public float timeToWin;
    bool won = false;

    //Menus
    public GameObject loseMenu;
    public GameObject winMenu;
    public Text counter;
    public GameObject counterSparkle;
    float numberCounter;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        GeneratePattern(patternAmmount);
        AddAxe();

        allPatterns.Reverse();

        NextPattern(allPatterns.Count);
                
        Debug.Log(allPatterns[currentPattern]);
        numberCounter = currentPattern + 1;
    }

 

    // Update is called once per frame
    void Update()
    {
        counter.text = (numberCounter).ToString();
        if (Time.time - currentTime > timeToWin)
        {
            won = true;
        }
        switch (currentState)
        {
            case GState.zones:

                if (currentPattern >= 0)
                {
                    if (Time.time - currentTime > timer)
                    {
                        if (won)
                        {
                            Win();
                            Debug.Log("Zone TimeWIN");
                        }
                        else {
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
                            }
                            else
                            {
                                Lose();
                                Debug.Log("Zone LOSE");
                            }
                        }
                    }
                }
                else
                {
                    Win();
                    Debug.Log("Zone Win");
                }

                break;
            case GState.axe:
                if (Time.time - currentTime > axeTimer)
                {
                    if (won)
                    {
                        Win();
                        Debug.Log("Axe TimeWIN");
                    } else
                    {
                        if (currentHits >= nHits)
                        {
                            if (currentPattern > 0)
                            {
                                currentTime = Time.time;
                                currentState = GState.wait;
                                treePrompt.SetActive(false);

                                SpawnSparkle();
                            }
                            else
                            {
                                Win();
                                Debug.Log("Axe Win");
                            }

                        }
                        else
                        {
                            tree.GetComponent<SpriteRenderer>().color = Color.white;
                            Lose();
                            Debug.Log("Axe Lose");
                        }
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

    void Lose()
    {
        tree.GetComponent<SpriteRenderer>().color = Color.white;
        currentState = GState.lose;
        loseMenu.SetActive(true);
    }

    void Win()
    {
        tree.GetComponent<SpriteRenderer>().color = Color.white;
        currentState = GState.win;
        winMenu.SetActive(true);
    }
    
    void NextPattern(int current)
    {
        currentPattern = current - 1;
        hit = false;

        if (currentPattern>=0)
        {
            currentTime = Time.time;

            tree.GetComponent<SpriteRenderer>().color = ColorReferencer.instance.GetColorRef(allPatterns[currentPattern]);
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

    void SpawnSparkle()
    {
        numberCounter--;
        //SPARKLE
        counterSparkle.SetActive(true);
        Instantiate(counterSparkle, counterSparkle.transform.parent);
        counterSparkle.SetActive(false);
    }

    public void CheckPattern(string pattern)
    {
        if (currentState == GState.zones)
        {
            if (pattern == allPatterns[currentPattern])
            {
                if (!hit)
                {
                    SpawnSparkle();
                }

                hit = true;                
                Debug.Log(pattern + " | " + allPatterns[currentPattern] + " | CORRECTO");
            }
            else
            {
                Lose();
            }
        }
    }

    public void SwingAxe()
    {
        currentHits++;
        Debug.LogWarning(currentHits);
    }
}
