using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fixpopupbug : MonoBehaviour
{
    public GameObject popup;
    private bool hasBeenDone = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenDone && popup != null){
            hasBeenDone = true;
            popup.SetActive(true);
        }
    }
}
