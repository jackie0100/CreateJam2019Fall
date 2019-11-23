using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBasic : MonoBehaviour
{
    public bool IsEnemy;
    private bool isAttacking; 
    public int MovementSpeed;
    public GameObject Target;
    // Start is called before the first frame update
    void Start()
    {
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isAttacking){
            Movement ();
        }
    }
    private void Movement () {        
        if (Vector3.Distance(transform.position, Target.transform.position) > 5){
            transform.position += AngleToTarget () * MovementSpeed * Time.deltaTime;
        }
    }

    private Vector3 AngleToTarget () {
        Vector3 angle = new Vector3();
        angle = Target.transform.position - transform.position;
        angle.Normalize();
        return angle; 
    }
}
