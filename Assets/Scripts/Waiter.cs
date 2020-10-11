using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    public float timer;
    float currentTime;
    public CamMove cM;
    public CamHoverEffect cHE;
    public CamZoomer cZ;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - currentTime> timer)
        {
            cM.enabled = true;
            cHE.enabled = true;
            cZ.enabled = true;
        }
    }
}
