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
   // public SpriteRenderer spriteRenderer;
    // Attack
    public float AttackSpeed;
    private float attackCountDown;
    public float SigtDistence;
    public int SightAngle;

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //spriteRenderer.sprite = Sprites[currentRotation];
        anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("Idle");

    }

    
    // Update is called once per frame
    void Update()
    {
        if (IsEnemy && !isFollowing){
            SpotTarget();
        }
        if (isFollowing){
            Movement ();
        }
    }
    private void SpotTarget () {
        LayerMask layerMask = 1 << 10;
        if(Physics2D.OverlapCircle(transform.position, SigtDistence, layerMask)) {
            print("Spotted!!");
            if (IsWithInAngle()){
                isFollowing = true;
                
            }
        } else {
            
        }
    }
    private bool IsWithInAngle () {
        Vector3 vector = transform.position - Target.transform.position;
         float angle = Mathf.Atan2(vector.y, vector.x) * 180 /Mathf.PI;
         angle = (angle + 360) % 360;
         float Langle = (currentRotation * 90 + SightAngle/2 + 360 - 90) % 360;
         float Rangle = (currentRotation * 90 - SightAngle/2 + 360 - 90) % 360;
         
         if (Rangle > Langle){             
             if (angle < Langle || angle > Rangle){
                 return true;
             }
         } else {
             if (angle < Langle && angle > Rangle){
                 return true;
             }
         }
         return false;
    }
    private void Movement () {        
        if (Vector3.Distance(transform.position, Target.transform.position) > AttackDistence){  
            attackCountDown = AttackSpeed;          
            
            Rotate ();
            GetComponent<Rigidbody2D>().velocity = AngleToTarget () * MovementSpeed;
        } else {
            Attacking ();
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            anim.SetTrigger("Attack");
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
            //spriteRenderer.sprite = Sprites[3];
            currentRotation = 3;
           
        } else if (rotation.x < -0.5){
            //spriteRenderer.sprite = Sprites[2];
            currentRotation = 2;
           

        } else if (rotation.y > 0){
            //spriteRenderer.sprite = Sprites[0];
            currentRotation = 0;
           
        } else {
            //spriteRenderer.sprite = Sprites[1];
            currentRotation = 1;
            

        }
        anim.SetInteger("Direction", currentRotation);
    }

    private Vector3 AngleToTarget () {
        Vector3 angle = new Vector3();
        angle = Target.transform.position - transform.position;
        angle.Normalize();
        return angle; 
    }

    
}
