using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    public float timer;
    public CamMove cM;
    public CamHoverEffect cHE;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timer)
        {
            cM.enabled = true;
            cHE.enabled = true;
        }
    }
}
