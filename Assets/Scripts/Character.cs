using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Health = 1;
    public int Damage;
    public float AttackOffSet;
    public GameObject AttackObject;
    public int currentRotation;

    
    public void TakeDamage (int damage) {
        Health -= damage;
        if (Health <= 0){
            Death();
            Destroy(this.gameObject);
        }
    }

    public void Attack () {
        GameObject attack = Instantiate(AttackObject, GetAttackPostion(), GetAttackRotation());
        Attack attackScript = attack.GetComponent<Attack>();
        attackScript.Damage = Damage;
        attackScript.Owner = this.gameObject;
    }
    private Vector3 GetAttackPostion() {
        Vector3 vector = transform.position;
        switch (currentRotation){
            case 0: {
                vector += Vector3.up * AttackOffSet;
                break;
            }
            case 1 : {                
                vector += Vector3.down * AttackOffSet;
                break;
            }
            case 2 : {                
                vector += Vector3.left * AttackOffSet;
                break;
            }
            case 3 : {
                vector += Vector3.right * AttackOffSet;
                break;
            }
            default: {
                break;
            }
        }
        return  vector;
    }
    public virtual  void Death(){

    }
    private Quaternion GetAttackRotation() {
        Quaternion quaternion = new Quaternion();
        switch (currentRotation){
            case 0: {
                quaternion = Quaternion.Euler(0,0,0);
                break;
            }
            case 1 : {                
                quaternion = Quaternion.Euler(0,0,180);
                break;
            }
            case 2 : {                
                quaternion = Quaternion.Euler(0,0,90);
                break;
            }
            case 3 : {
                quaternion = Quaternion.Euler(0,0, 270);
                break;
            }
            default: {
                break;
            }
        }
        return  quaternion;
    }
}
