using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBasic : Character
{
    // Movement 
    public List<Sprite> Sprites;
    public bool IsEnemy;
    public bool isFollowing; 
    public int MovementSpeed;
    public float AttackDistence;
    public GameObject Target;
    public SpriteRenderer spriteRenderer;
    // Attack
    public float AttackSpeed;
    private float attackCountDown;
    // Start is called before the first frame update
    void Start()
    {
    }

    
    // Update is called once per frame
    void Update()
    {
        if (isFollowing){
            Movement ();
        }
    }
    private void Movement () {        
        if (Vector3.Distance(transform.position, Target.transform.position) > AttackDistence){  
            attackCountDown = AttackSpeed;          
            GetComponent<Rigidbody2D>().velocity = AngleToTarget () * MovementSpeed;
            Rotate ();
        } else {
            Attacking ();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
    private void Attacking () {
        if (attackCountDown <= 0){            
            attackCountDown = AttackSpeed;
            Attack();
        } else {
            attackCountDown -= Time.deltaTime;
        }
    }
    private void Rotate () {
        Vector3 rotation = Target.transform.position - transform.position;
        if (rotation.x > 0.5){
            spriteRenderer.sprite = Sprites[3];
            currentRotation = 3;
        } else if (rotation.x < -0.5){
            spriteRenderer.sprite = Sprites[2];
            currentRotation = 3;

        } else if (rotation.y > 0){
            spriteRenderer.sprite = Sprites[0];
            currentRotation = 3;
        } else {
            spriteRenderer.sprite = Sprites[1];
            currentRotation = 3;
        }
    }

    private Vector3 AngleToTarget () {
        Vector3 angle = new Vector3();
        angle = Target.transform.position - transform.position;
        angle.Normalize();
        return angle; 
    }

    
}
