using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : Item
{
    public CreateLoot loot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<BackPack>().Loots.Add(loot);
            Destroy(this.gameObject);
        }
    }
}
