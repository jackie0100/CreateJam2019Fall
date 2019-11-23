using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int Damage; 
    public GameObject Owner;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            print("entered");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject != Owner && other.GetComponent<Character>())
        {
            other.GetComponent<Character>().TakeDamage(Damage);
            print("npc trigger");
        }
    }
}
