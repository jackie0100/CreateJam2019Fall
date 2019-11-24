using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPack : MonoBehaviour
{
    public int Coins = 0;
    public List<CreateLoot> Loots;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddLoot (CreateLoot loot) {
        Loots.Add(loot);
    }
}
