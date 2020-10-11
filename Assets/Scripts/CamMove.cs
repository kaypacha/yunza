using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform cam;

    public Transform target;
    public Transform scene;
    public Vector2 test;

    public float rotateSpeed;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        test = (Vector2)cam.position + Vector2.up;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(cam.position, test, Color.white);


        float a = Vector2.SignedAngle(test, target.position) * Mathf.PI / 180 * Time.deltaTime*rotateSpeed;
        float nX = test.x * Mathf.Cos(a)- test.y*Mathf.Sin(a);
        float nY = test.x * Mathf.Sin(a) + test.y * Mathf.Cos(a);
        test = new Vector2(nX, nY);

        //float b = Vector2.SignedAngle(cam.position, test2.position);
        //Debug.Log(b);

        scene.Translate(test*speed*-Time.deltaTime);


        //cam.position = Vector3.MoveTowards(cam.position,cam.position+(Vector3)test,maxDelta);

        //test = Vector3.RotateTowards(test, test2.position, 0.01f, 0);
        //cam.GetComponent<Rigidbody2D>().velocity = new Vector2(test.x-cam.position.x,test.y-cam.position.y);
        //Vector3 newPos = new Vector3(cam.position.x + test.x * Time.deltaTime, cam.position.y + test.y * Time.deltaTime, cam.position.z);

        //cam.position = newPos;
    }
}
