using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splinterer : MonoBehaviour
{

    Rigidbody2D rb;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    public float multForce;
    float timeStart;
    public float lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float nX = Random.Range(minX,maxX);
        float nY = Random.Range(minY, maxY);
        Vector2 force = new Vector2(nX*multForce, nY * multForce);

        timeStart = Time.time;

        rb.velocity = force;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeStart > lifeTime)
        {
            Destroy(this);
        }
    }
}
