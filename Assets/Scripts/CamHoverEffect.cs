using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CamHoverEffect : MonoBehaviour
{
    public Transform camTransform;
    public float circleBound = 0.7f;
    public float deltaMove = 0.5f;

    Vector2 originalPos;
    bool goCenter;
    Vector2 targetPos;

    public Transform targetTransform;
    public Transform center;

    float currentTime;
    public float timer;

    public bool showCircle;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = Time.time;


    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(test,originalPos);
        //test = Vector3.RotateTowards(test,test2.position,0.2f,0);
        

        //Debug.DrawLine(camTransform.position, targetPos);
        //Debug.DrawLine(originalPos,((Vector3)targetPos-camTransform.position),Color.red);
        if (Time.time - currentTime > timer)
        {
            SetNewTargetPos();
            currentTime = Time.time;
        }
        else
        {
            //float speed = deltaMove * Time.deltaTime;
            //camTransform.position = camTransform.position + (Vector3)test * 0.01f;//Vector2.MoveTowards(camTransform.position, targetPos,speed);
        }
    }

    void SetNewTargetPos()
    {
        if (!goCenter)
        {
            targetPos = (Vector2)center.position + Random.insideUnitCircle * circleBound;
            goCenter = true;
        } else
        {
            targetPos = (Vector2)center.position;
            goCenter = false;
        }
        targetTransform.position = targetPos;

    }

    private void OnDrawGizmos()
    {
        if (showCircle)
        {
            Gizmos.DrawSphere((Vector2)center.position, circleBound * 1);
        }
    }
}
