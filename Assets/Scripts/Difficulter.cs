using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulter : MonoBehaviour
{
    public static Difficulter instance;


    public AnimationCurve dificultyCurve;

    public float timePassed;
    public float maxTime;
    
    float currentKey;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        currentKey = Time.time / maxTime;
        timePassed = Time.time;
        Debug.Log(timePassed + " | " + Time.time + " | " + dificultyCurve.Evaluate(currentKey));
    }

    public float Check()
    {
        return dificultyCurve.Evaluate(currentKey);
    }
}
