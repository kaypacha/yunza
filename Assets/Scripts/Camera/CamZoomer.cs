using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoomer : MonoBehaviour
{

    public Camera cam;

    public float minSize;
    public float maxSize;

    float currentSize;
    float targetSize;

    float currentTime;
    public float baseTime;
    public float changeTime;

    public float sizeSpeed;
    float inter;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - currentTime > baseTime-changeTime*Difficulter.instance.Check())
        {
            targetSize = Random.Range(minSize,maxSize);
            currentSize = cam.orthographicSize;
            currentTime = Time.time;
            inter = 0;
        }

        if (inter < 1)
        {
            inter += Time.deltaTime * sizeSpeed;
        } else
        {
            inter = 1;
        }

        if (currentSize != 0)
        {
            cam.orthographicSize = Mathf.Lerp(currentSize, targetSize, inter);
        }
    }
}
