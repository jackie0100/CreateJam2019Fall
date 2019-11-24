using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.GetComponent<Item>())
        {
            collision.gameObject.GetComponent<Item>().target = this.gameObject;
            //collision.transform.position = Vector2.MoveTowards(collision.transform.position, this.transform.position, 0.1f);
        }
    }
}
