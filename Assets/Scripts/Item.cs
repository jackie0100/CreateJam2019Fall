using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject target;
    Rigidbody2D rigidbody;
    float maxV = 4;
    float deAcc = 0.1f;
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
        } 
        if (rigidbody.velocity != Vector2.zero){
            float x = rigidbody.velocity.x;
            float y = rigidbody.velocity.y;
            if (x > 0){
                x =(x < maxV)? x - deAcc: maxV;
            } else {
                x =(x > -maxV)? x + deAcc: - maxV;
            }
            if (y > 0){
                y =(y < maxV)? y - deAcc: maxV;
            } else {
                x =(y > -maxV)? y + deAcc: - maxV;
            }
            rigidbody.velocity = new Vector2(x,y);
        }
    }
}
