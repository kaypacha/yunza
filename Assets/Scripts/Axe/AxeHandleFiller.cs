using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxeHandleFiller : MonoBehaviour
{

    public Image imgRef;

    // Start is called before the first frame update
    void Start()
    {
        imgRef = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        PaceManager temp = PaceManager.instance;
        if (temp.currentState == PaceManager.GState.axe)
        {   
            Debug.Log(temp.GetCurrentHits() / temp.nHits + "|" + temp.GetCurrentHits() + " - " + temp.nHits);
            imgRef.fillAmount = (float)temp.GetCurrentHits() / (float)temp.nHits;
        } else
        {
            imgRef.fillAmount = 0;
        }
        
    }
}
