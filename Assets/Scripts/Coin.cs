﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<BackPack>().Coins += 1;
            Destroy(this.gameObject);
        }
    }
}
