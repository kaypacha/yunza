using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEntity : MonoBehaviour
{

    public string patternZone;

    public KeyCode keyboardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyboardInput))
        {
            PaceManager.instance.CheckPattern(patternZone);
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PaceManager.instance.CheckPattern(patternZone);
            //TO DO: SPAWN FUEGOS ARTIFICIALES
        }
    }
}
