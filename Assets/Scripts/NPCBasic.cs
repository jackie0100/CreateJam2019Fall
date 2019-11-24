﻿using System.Collections;
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
    public float SigtDistence;
    public int SightAngle; 
    // Loot
    public GameObject Coin;
    public int Coins;
    public List<GameObject> loots = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.sprite = Sprites[currentRotation];
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
            currentRotation = 2;

        } else if (rotation.y > 0){
            spriteRenderer.sprite = Sprites[0];
            currentRotation = 0;
        } else {
            spriteRenderer.sprite = Sprites[1];
            currentRotation = 1;
        }
    }

    private Vector3 AngleToTarget () {
        Vector3 angle = new Vector3();
        angle = Target.transform.position - transform.position;
        angle.Normalize();
        return angle; 
    }

    public override void Death() {
        if (Coins > 0){
            for (int i = 0; i < Coins; i ++){
                GameObject coins = Instantiate (Coin, transform.position, transform.rotation);
                float angle = Random.Range(0,360) * Mathf.PI/180;
                Vector3 dirc = new Vector3(Mathf.Cos(angle),Mathf.Sin(angle), 0);
                coins.GetComponent<Rigidbody2D>().velocity = new Vector2(dirc.x, dirc.y) * 10;
            }
        }
        if (loots.Count > 0){
            foreach (GameObject loot in loots){
                GameObject newLoot = Instantiate (loot, transform.position, transform.rotation);
                float angle = Random.Range(0,360) * Mathf.PI/180;
                Vector3 dirc = new Vector3(Mathf.Cos(angle),Mathf.Sin(angle), 0);
                newLoot.GetComponent<Rigidbody2D>().velocity = new Vector2(dirc.x, dirc.y) * 10;

            }
        }
    }
}
