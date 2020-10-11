using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musicer : MonoBehaviour
{

    public AudioSource source;
    public float targetVolume;
    float inter = 0;
    public float changeSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inter < 1)
        {
            inter += changeSpeed * Time.deltaTime;
        } else
        {
            inter = 1;
        }

        source.volume = Mathf.Lerp(0,targetVolume,inter);
    }
}
