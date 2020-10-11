using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axer : MonoBehaviour
{

    public GameObject pref;
    public float spawnRadius;

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
            Vector2 temp = Random.insideUnitCircle * spawnRadius;
            Instantiate(pref,temp,transform.rotation);
            PaceManager.instance.SwingAxe();
            //TO DO: SPAWN ASTILLAS
        }
    }
}
