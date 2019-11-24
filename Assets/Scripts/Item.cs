using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject target;
    Rigidbody2D rigidbody;
    float maxV = 10;
    float deAcc = 1;
    // Start is called before the first frame update
    [HideInInspector]
    void Start()
    {        
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null){            
            Vector3 vector = (target.transform.position - transform.position).normalized;
            
            print(vector);
            rigidbody.velocity += new Vector2(vector.x, vector.y);
        } else if (rigidbody.velocity != Vector2.zero){
            float x = rigidbody.velocity.x;
            float y = rigidbody.velocity.y;
            if (x > maxV){
                x -= deAcc;
            } else if (x < -maxV){
                x += deAcc;
            }
            if (y > -maxV){
                y -= deAcc;
            } else if (y < -maxV){
                y += deAcc;
            }
            rigidbody.velocity = new Vector2(x,y);
        }
    }
}
