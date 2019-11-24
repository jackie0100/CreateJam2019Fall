using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAfterTime : MonoBehaviour
{
    public float Timer = 0; 
    void Update()
    {
        if (Timer < 0) {
            Destroy(this.gameObject);
        } else {
            Timer -= Time.deltaTime;
        }
    }
}
