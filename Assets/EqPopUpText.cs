﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EqPopUpText : MonoBehaviour
{

    public int Countdown = 2;
    private float countingDown = 0;
    void OnEnable () {
        countingDown = Countdown;
    }
    void Update () {
        if (countingDown <= 0){
            gameObject.SetActive(false);
        } else {
            countingDown -= Time.deltaTime;
        }
    }
}
