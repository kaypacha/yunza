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
    Vector2 targetPos;

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
        Debug.DrawLine(camTransform.position, targetPos);
        if (Time.time - currentTime > timer)
        {
            SetNewTargetPos();
            currentTime = Time.time;
        }
        else
        {
            float speed = deltaMove * Time.deltaTime;
            camTransform.position = Vector2.MoveTowards(camTransform.position, targetPos,speed);
        }
    }

    void SetNewTargetPos()
    {
        targetPos = originalPos + Random.insideUnitCircle * circleBound;
    }

    private void OnDrawGizmos()
    {
        if (showCircle)
        {
            Gizmos.DrawSphere(originalPos, circleBound * 1);
        }
    }
}
