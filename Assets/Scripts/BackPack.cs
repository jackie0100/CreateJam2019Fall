using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class BackPack
{
    static public int Coins = 0;
    static public List<CreateLoot> Loots = new List<CreateLoot>();
    static public void AddLoot (CreateLoot loot) {
        Loots.Add(loot);
    }
}
