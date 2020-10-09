using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneEntity : MonoBehaviour
{

    public string patternZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            PaceManager.instance.CheckPattern(patternZone);
        }
    }
}
