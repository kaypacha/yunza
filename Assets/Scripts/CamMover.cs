using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMover : MonoBehaviour
{
    
    public Transform pivot;


    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float a = Vector2.SignedAngle(pivot.position, target.position) * Mathf.PI / 180 * Time.deltaTime;
        float nX = pivot.position.x * Mathf.Cos(a) - pivot.position.y * Mathf.Sin(a);
        float nY = pivot.position.x * Mathf.Sin(a) + pivot.position.y * Mathf.Cos(a);
        pivot.position = new Vector2(nX, nY);
    }
}
